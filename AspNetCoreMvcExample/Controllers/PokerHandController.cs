using System.Collections.Generic;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcExample.Controllers
{
    public class PokerHandController : Controller
    {
        private readonly ICardsService<CardModel> _pokerCardsService;

        public PokerHandController(ICardsService<CardModel> pokerCardsService)
        {
            _pokerCardsService = pokerCardsService;
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
            _pokerCardsService.DealCards();
            model.Cards = _pokerCardsService.DealtCards;
            return View(nameof(Index), model);
        }
    }
}