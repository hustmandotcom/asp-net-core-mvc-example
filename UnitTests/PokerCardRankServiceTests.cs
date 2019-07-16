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
        private PokerCardsRankingService _pokerCardRankingService;
        private PokerCardsDealingService _pokerCardsDealingService;

        [SetUp]
        public void Setup()
        {
            _pokerCardRankingService = new PokerCardsRankingService();
            _pokerCardsDealingService = new PokerCardsDealingService();
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.HighCard));
        }

        [Test]
        public void AceLowAceHighSetCardsAreRankedCorrectly()
        {
            // arrange
            var cards = new List<CardModel>();
            cards.Add(new CardModel() {Face = Face.AceHigh, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.AceLow, Suit = Suit.Heart});
            cards.Add(new CardModel() {Face = Face.Six, Suit = Suit.Spade});
            cards.Add(new CardModel() {Face = Face.Three, Suit = Suit.Club});
            cards.Add(new CardModel() {Face = Face.Seven, Suit = Suit.Club});

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.OnePair));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.OnePair));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.TwoPair));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.ThreeOfAKind));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.Straight));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.Straight));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.Flush));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.FullHouse));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.FourOfAKind));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.StraightFlush));
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

            _pokerCardsDealingService.SetCards(cards);

            // act
            var rank = _pokerCardRankingService.GetRank(cards);

            // assert
            Assert.That(rank.Equals(Rank.RoyalFlush));
        }
    }
}