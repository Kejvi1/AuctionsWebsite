using AuctionsWebsite.Models;
using Contracts;
using Entities.DTO.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionsWebsite.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IUnitOfWork _repository;

        public AuthController(ILoggerManager logger, IUnitOfWork repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO loginObj)
        {
            if (!ModelState.IsValid)
                return View(loginObj);

            try
            {
                var user = _repository.Auth.Login(loginObj);

                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("uid", user.Id.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Auction");
                }

                else
                    ViewBag.Result = "User not found!";

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Login action: {ex.Message}!");
                ViewBag.Result = "There was an error trying to authenticate! Please try again later!";
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterDTO registerObj)
        {
            if (!ModelState.IsValid)
                return View(registerObj);

            try
            {
                bool isPresent = _repository.Auth.GetByUsername(registerObj.Username);

                if (isPresent)
                    ViewBag.Result = "There exists a user with the same credentials!";

                else
                {
                    _repository.Auth.Register(registerObj);
                    _repository.Save();

                    ViewBag.Result = "User registered successfully!";

                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}!");
                ViewBag.Result = "There was an error trying to register user! Please try again later!";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}