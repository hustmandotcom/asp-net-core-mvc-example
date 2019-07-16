using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreMvcExample.Extensions;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public class PokerCardsDealingService : ICardsDealingService<CardModel>
    {
        private const int NumberOfDealtCards = 5;
        private readonly Random _random = new Random();
        public IEnumerable<CardModel> DealtCards { get; private set; }

        public void DealCards()
        {
            DealtCards = GetRandomCards(NumberOfDealtCards);
        }

        public void SetCards(IEnumerable<CardModel> cards)
        {
            var cardModels = cards as CardModel[] ?? cards.ToArray();
            if (!cardModels.Count().Equals(NumberOfDealtCards))
                throw new ArgumentOutOfRangeException($"cards array must contain {NumberOfDealtCards} members");

            DealtCards = cardModels;
        }

        private IEnumerable<CardModel> GetRandomCards(int numberOfCards)
        {
            var dealtCards = new List<CardModel>();
            for (var i = 0; i < numberOfCards; i++)
            {
                var randomCard = GetRandomCard();
                while (dealtCards.Contains(randomCard))
                {
                    randomCard = GetRandomCard();
                }
                dealtCards.Add(randomCard);
            }

            return dealtCards;
        }

        private CardModel GetRandomCard()
        {
            return new CardModel()
            {
                Suit = Suit.Club.GetRandomEnum(),
                Face = Face.Six.GetRandomEnum()
            };
        }

    }
}
