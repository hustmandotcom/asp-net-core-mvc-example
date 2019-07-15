using System.Linq;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using NUnit.Framework;

namespace AspNetCoreMvcExample.UnitTests
{
    public class PokerCardServiceTests
    {
        private ICardsService<CardModel> _pokerCardsService;
        [SetUp]
        public void Setup()
        {
            _pokerCardsService = new PokerCardsService();
        }

        [Test]
        public void DealingCardsGetsFiveCards()
        {
            // act
            _pokerCardsService.DealCards();

            // assert
            Assert.That(_pokerCardsService.DealtCards.Count().Equals(5));
        }

        [Test]
        public void DealtCardsDoNotContainDuplicates()
        {
            // act
            _pokerCardsService.DealCards();
            var duplicateCards = _pokerCardsService.DealtCards.GroupBy(card => card).Where(cards => cards.Count() > 1)
                .Select(card => card.Key);

            // assert
            Assert.That(!duplicateCards.Any());
        }
    }
}