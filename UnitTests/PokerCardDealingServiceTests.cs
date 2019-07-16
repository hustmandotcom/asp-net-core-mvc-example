using System;
using System.Linq;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using NUnit.Framework;

namespace AspNetCoreMvcExample.UnitTests
{
    public class PokerCardDealingServiceTests
    {
        private ICardsDealingService<CardModel> _pokerCardsDealingService;
        [SetUp]
        public void Setup()
        {
            _pokerCardsDealingService = new PokerCardsDealingService();
        }

        [Test]
        public void DealingCardsGetsFiveCards()
        {
            // act
            _pokerCardsDealingService.DealCards();

            // assert
            Assert.That(_pokerCardsDealingService.DealtCards.Count().Equals(5));
        }

        [Test]
        public void FourCardsThrowsArgumentOutOfRangeException()
        {
            // act
            var cardsArray = new CardModel[4]
            {
                new CardModel(),
                new CardModel(),
                new CardModel(),
                new CardModel(),
            };

            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _pokerCardsDealingService.SetCards(cardsArray));
        }

        [Test]
        public void DealtCardsDoNotContainDuplicates()
        {
            // act
            _pokerCardsDealingService.DealCards();
            var duplicateCards = _pokerCardsDealingService.DealtCards.GroupBy(card => card).Where(cards => cards.Count() > 1)
                .Select(card => card.Key);

            // assert
            Assert.That(!duplicateCards.Any());
        }

    }
}