using System.Collections.Generic;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcExample.Controllers
{
    public class PokerHandController : Controller
    {
        private readonly ICardsDealingService<CardModel> _pokerCardsDealingService;
        private readonly ICardsRankingService<CardModel, Rank> _pokerCardsRankingService;

        public PokerHandController(ICardsDealingService<CardModel> pokerCardsDealingService, ICardsRankingService<CardModel, Rank> pokerCardsRankingService)
        {
            _pokerCardsDealingService = pokerCardsDealingService;
            _pokerCardsRankingService = pokerCardsRankingService;
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
            _pokerCardsDealingService.DealCards();
            model.Cards = _pokerCardsDealingService.DealtCards;
            model.Rank = _pokerCardsRankingService.GetRank(model.Cards);
            return View(nameof(Index), model);
        }
    }
}