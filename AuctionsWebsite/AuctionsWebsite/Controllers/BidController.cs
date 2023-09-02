using Contracts;
using Entities.DAO.Bid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AuctionsWebsite.Controllers
{
    [Authorize]
    public class BidController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IUnitOfWork _repository;

        public BidController(ILoggerManager logger, IUnitOfWork repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult PlaceBid(int id, double highestBid, double amount)
        {
            try
            {
                if (amount <= highestBid)
                {
                    TempData["AmountErr"] = "Input amount is lower than the highest bid!";
                    return RedirectToAction("Details", "Auction", new { id });
                }

                var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value);

                var wallet = _repository.Wallet.GetWalletForUser(userId);

                if (wallet == null)
                {
                    TempData["Result"] = "Wallet not found for user!";
                    return RedirectToAction("Details", "Auction", new { id });
                }

                if (amount > wallet.Amount)
                {
                    TempData["AmountErr"] = "Input amount is greater than the users wallet!";
                    return RedirectToAction("Details", "Auction", new { id });
                }

                _repository.Bid.PlaceBid(new BidDAO { AuctionId = id, Amount = amount, UserId = userId });
                _repository.Save();

                return RedirectToAction("Index", "Auction");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PlaceBid action: {ex.Message}!");
                TempData["Result"] = "There was an error placing the bid! Please try again later!";
                return RedirectToAction("Details", "Auction", new { id });
            }
        }
    }
}