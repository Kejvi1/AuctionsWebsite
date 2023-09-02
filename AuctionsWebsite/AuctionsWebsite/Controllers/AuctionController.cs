using Contracts;
using Entities.DTO.Auction;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
            try
            {
                var wallet = _repository.Wallet.GetWalletForUser(Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value));

                if (wallet == null)
                {
                    ViewBag.Result = "There isn't any wallet for this user!";
                    return View();
                }

                var auctions = _repository.Auction.GetAuctions();

                var dto = new CurrentAuctionsDTO { CurrentWalletAmount = wallet.Amount, Auctions = auctions };

                return View(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong getting auctions: {ex.Message}!");
                ViewBag.Result = "There was an error getting data from database! Please try again later!";

                return View();
            }
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

                var uid = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

                if (string.IsNullOrWhiteSpace(uid))
                {
                    _logger.LogError($"Something went wrong inside Create action: Couldn't fetch userId!");

                    ViewBag.Result = "There was an error creating the auction! Please try again later!";
                    return View(auction);
                }

                _repository.Auction.CreateAuction(auction, prod.Id, Convert.ToInt32(uid));
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var auction = _repository.Auction.GetAuctionById(id);

                if (auction == null)
                    ViewBag.Result = "The auction doesn't exist!";

                else
                {
                    _repository.Auction.DeleteAuction(auction);
                    _repository.Save();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Delete action: {ex.Message}!");
                ViewBag.Result = "There was an error deleting the auction! Please try again later!";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Auth");
        }
    }
}