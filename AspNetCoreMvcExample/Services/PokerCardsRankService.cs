using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public class PokerCardsRankService : IRankService<CardModel>
    {
        public string GetRank(CardModel cards)
        {
            return "";
        }
    }
}
