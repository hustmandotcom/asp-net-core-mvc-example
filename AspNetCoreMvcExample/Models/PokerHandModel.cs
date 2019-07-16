using System.Collections.Generic;
using AspNetCoreMvcExample.Extensions;

namespace AspNetCoreMvcExample.Models
{
    public class PokerHandModel
    {
        public IEnumerable<CardModel> Cards { get; set; }
        public Rank Rank { get; set; }

        public string GetRankString()
        {
            return $"{Rank.GetDescription()}";
        }
    }
}
