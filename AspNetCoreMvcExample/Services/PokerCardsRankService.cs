using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public class PokerCardsRankService : IRankService<CardModel>
    {
        public Rank GetRank(IEnumerable<CardModel> cards)
        {
            var rank = Rank.HIGH_CARD;

            var cardModels = cards as CardModel[] ?? cards.ToArray();

            if (IsOnePair(cardModels))
                rank = Rank.ONE_PAIR;

            if (IsTwoPair(cardModels))
                rank = Rank.TWO_PAIR;

            if (IsThreeOfAKind(cardModels))
                rank = Rank.THREE_OF_A_KIND;

            if (IsStraight(cardModels))
                rank = Rank.STRAIGHT;

            if (IsFlush(cardModels))
                rank = Rank.FLUSH;

            if (IsFullHouse(cardModels))
                rank = Rank.FULL_HOUSE;

            if (IsFourOfAKind(cardModels))
                rank = Rank.FOUR_OF_A_KIND;

            if (IsStraightFlush(cardModels))
                rank = Rank.STRAIGHT_FLUSH;

            if (IsRoyalFlush(cardModels))
                rank = Rank.ROYAL_FLUSH;

            return rank;
        }

        private bool IsRoyalFlush(IEnumerable<CardModel> cards)
        {
            var cardModels = cards as CardModel[] ?? cards.ToArray();
            var isStraightFlush = IsStraightFlush(cardModels);
            return isStraightFlush && cardModels.Select(c => c.Face).Contains(Face.AceHigh);
        }

        private bool IsStraightFlush(IEnumerable<CardModel> cards)
        {
            var cardModels = cards as CardModel[] ?? cards.ToArray();
            return IsStraight(cardModels) && IsFlush(cardModels);
        }

        private bool IsFourOfAKind(IEnumerable<CardModel> cards)
        {
            var query = cards.GroupBy(
                card => card.Face,
                card => card.Face,
                (face, enumerable) => new
                {
                    Key = face,
                    Count = enumerable.Count()
                });

            foreach (var result in query)
            {
                if (result.Count == 4)
                    return true;
            }

            return false;
        }

        private bool IsFullHouse(IEnumerable<CardModel> cards)
        {
            var query = cards.GroupBy(
                card => card.Face,
                card => card.Face,
                (face, enumerable) => new
                {
                    Key = face,
                    Count = enumerable.Count()
                });

            var threeOfAKind = 0;
            var twoOfAKind = 0;

            foreach (var result in query)
            {
                if (result.Count == 3)
                    threeOfAKind++;
                if (result.Count == 2)
                    twoOfAKind++;
            }
            return threeOfAKind == 1 && twoOfAKind == 1;
        }

        private bool IsFlush(IEnumerable<CardModel> cards)
        {
            var query = cards.GroupBy(
                card => card.Suit,
                card => card.Suit,
                (suit, enumerable) => new
                {
                    Key = suit,
                    Count = enumerable.Count()
                });

            foreach (var result in query)
            {
                if (result.Count == 5)
                    return true;
            }
            return false;
        }

        private bool IsStraight(IEnumerable<CardModel> cards)
        {
            var faces = cards.Select(c => c.Face).ToArray();
            Array.Sort(faces);
            var previousFaceValue = -1;
            foreach (var face in faces)
            {
                var faceValue = (int)face;
                if (previousFaceValue < 0)
                    previousFaceValue = faceValue;
                else
                {
                    if (faceValue == previousFaceValue + 1)
                        previousFaceValue = faceValue;
                    else
                        return false;
                }
            }
            return true;
        }

        private bool IsThreeOfAKind(IEnumerable<CardModel> cards)
        {
            var query = cards.GroupBy(
                card => card.Face,
                card => card.Face,
                (face, enumerable) => new
                {
                    Key = face,
                    Count = enumerable.Count()
                });

            foreach (var result in query)
            {
                if (result.Count == 3)
                    return true;
            }

            return false;
        }

        private bool IsTwoPair(IEnumerable<CardModel> cards)
        {
            var query = cards.GroupBy(
                card => card.Face,
                card => card.Face,
                (face, enumerable) => new
                {
                    Key = face,
                    Count = enumerable.Count()
                });
            var pairsCount = 0;

            foreach (var result in query)
            {
                if (result.Count == 2)
                    pairsCount++;
            }

            return pairsCount == 2;
        }

        private bool IsOnePair(IEnumerable<CardModel> cards)
        {
            var query = cards.GroupBy(
                card => card.Face,
                card => card.Face,
                (face, enumerable) => new
                {
                    Key = face,
                    Count = enumerable.Count()
                });
            var pairsCount = 0;

            foreach (var result in query)
            {
                if (result.Count == 2)
                    pairsCount++;
            }

            return pairsCount == 1;
        }

    }
}