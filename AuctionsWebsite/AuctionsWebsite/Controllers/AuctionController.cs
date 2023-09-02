using Contracts;
using Entities.DTO.Auction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuctionsWebsite.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IUnitOfWork _repository;

        public AuctionController(ILoggerManager logger, IUnitOfWork repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuctionDTO auction)
        {
            if (!ModelState.IsValid)
                return View(auction);

            try
            {
                var prod = _repository.Product.GetProduct(auction.ProductName, auction.ProductDescription);

                if (prod == null)
                {
                    ViewBag.Result = "Product name or description does not exist!";
                    return View(auction);
                }

                _repository.Auction.CreateAuction(auction, prod);
                _repository.Save();

                ViewBag.Result = "Auction created successfully!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Create action: {ex.Message}!");
                ViewBag.Result = "There was an error creating the auction! Please try again later!";

                return View(auction);
            }
        }
    }
}