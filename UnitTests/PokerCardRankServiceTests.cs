using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreMvcExample.Models;
using AspNetCoreMvcExample.Services;
using NUnit.Framework;

namespace AspNetCoreMvcExample.UnitTests
{
    class PokerCardRankServiceTests
    {
        private PokerCardsRankService _pokerCardRankService;
        private PokerCardDealingService _pokerCardDealingService;

        [SetUp]
        public void Setup()
        {
            _pokerCardRankService = new PokerCardsRankService();
            _pokerCardDealingService = new PokerCardDealingService();
        }

        [Test]
        public void HighCardSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ace, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Queen, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Three, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.HIGH_CARD));
        }

        [Test]
        public void OnePairSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ace, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Ace, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Three, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.ONE_PAIR));
        }

        [Test]
        public void TwoPairSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ace, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Ace, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.TWO_PAIR));
        }
    }
}