using System;
using System.Linq;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using NUnit.Framework;

namespace AspNetCoreMvcExample.UnitTests
{
    public class PokerCardDealingServiceTests
    {
        private ICardDealingService<CardModel> _pokerCardDealingService;
        [SetUp]
        public void Setup()
        {
            _pokerCardDealingService = new PokerCardDealingService();
        }

        [Test]
        public void DealingCardsGetsFiveCards()
        {
            // act
            _pokerCardDealingService.DealCards();

            // assert
            Assert.That(_pokerCardDealingService.DealtCards.Count().Equals(5));
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
            Assert.Throws<ArgumentOutOfRangeException>(() => _pokerCardDealingService.SetCards(cardsArray));
        }

        [Test]
        public void DealtCardsDoNotContainDuplicates()
        {
            // act
            _pokerCardDealingService.DealCards();
            var duplicateCards = _pokerCardDealingService.DealtCards.GroupBy(card => card).Where(cards => cards.Count() > 1)
                .Select(card => card.Key);

            // assert
            Assert.That(!duplicateCards.Any());
        }

    }
}