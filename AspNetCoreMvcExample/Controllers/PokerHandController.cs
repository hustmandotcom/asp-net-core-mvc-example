using System.Collections.Generic;
using AspNetCoreMvcExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcExample.Controllers
{
    public class PokerHandController : Controller
    {
        public IActionResult Index()
        {
            var model = new PokerHandModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult DealCards()
        {
            var model = new PokerHandModel();
            var dealtCards = new List<CardModel>();
            for (int i = 0; i < 5; i++)
            {
                dealtCards.Add(new CardModel(){Suit = "H", Value = "2"});
            }

            model.Cards = dealtCards;
            return View(nameof(Index), model);
        }
    }
}