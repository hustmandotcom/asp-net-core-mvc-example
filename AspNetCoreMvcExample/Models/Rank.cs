using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcExample.Models
{
    public enum Rank
    {
        [Description("High Card")] HighCard,
        [Description("One Pair")] OnePair,
        [Description("Two Pair")] TwoPair,
        [Description("Three of a Kind")] ThreeOfAKind,
        [Description("Straight")] Straight,
        [Description("Flush")] Flush,
        [Description("Full House")] FullHouse,
        [Description("Four of a Kind")] FourOfAKind,
        [Description("Straight Flush")] StraightFlush,
        [Description("Royal Flush")] RoyalFlush,
    }
}
