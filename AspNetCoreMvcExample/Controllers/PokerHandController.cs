using System.Collections.Generic;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcExample.Controllers
{
    public class PokerHandController : Controller
    {
        private readonly ICardDealingService<CardModel> _pokerCardDealingService;

        public PokerHandController(ICardDealingService<CardModel> pokerCardDealingService)
        {
            _pokerCardDealingService = pokerCardDealingService;
        }

        public IActionResult Index()
        {
            var model = new PokerHandModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult DealCards()
        {
            var model = new PokerHandModel();
            _pokerCardDealingService.DealCards();
            model.Cards = _pokerCardDealingService.DealtCards;
            return View(nameof(Index), model);
        }
    }
}