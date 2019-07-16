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
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Club});
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
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Heart});
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
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.TWO_PAIR));
        }

        [Test]
        public void ThreeOfAKindSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.THREE_OF_A_KIND));
        }

        [Test]
        public void AceLowStraightSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Two, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Three, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Four, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Five, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.STRAIGHT));
        }

        [Test]
        public void AceHighStraightSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Jack, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Queen, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.King, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.STRAIGHT));
        }

        [Test]
        public void FlushSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Jack, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.King, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.FLUSH));
        }

        [Test]
        public void FullHouseSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.FULL_HOUSE));
        }


        [Test]
        public void FourOfAKindSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Club});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.FOUR_OF_A_KIND));
        }


        [Test]
        public void StraightFlushSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Nine, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Jack, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Queen, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.King, Suit = Suit.Diamond});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.STRAIGHT_FLUSH));
        }

        [Test]
        public void RoyalFlushSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.Ten, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Jack, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.Queen, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.King, Suit = Suit.Diamond});
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Diamond});

            _pokerCardDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.ROYAL_FLUSH));
        }
    }
}