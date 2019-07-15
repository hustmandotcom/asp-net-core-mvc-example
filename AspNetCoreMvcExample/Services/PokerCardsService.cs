using System;
using System.Collections.Generic;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public class PokerCardsService : ICardsService<CardModel>
    {
        private const int NumberOfDealtCards = 5;
        private readonly string[] _availableSuits = {"S", "H", "D", "C"};
        private readonly string[] _availableValues = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        private readonly Random _random = new Random();
        public IEnumerable<CardModel> DealtCards { get; private set; }

        public void DealCards()
        {
            var dealtCards = new List<CardModel>();
            for (var i = 0; i < NumberOfDealtCards; i++)
            {
                dealtCards.Add(new CardModel(){Suit = "H", Value = "2"});
            }

            DealtCards = dealtCards;
        }

        public CardModel GetRandomCard()
        {
            return new CardModel()
            {
                Suit = _availableSuits[_random.Next(0, _availableSuits.Length)],
                Value = _availableValues[_random.Next(0, _availableValues.Length)]
            };
        }
    }
}
