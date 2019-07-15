using System.Collections.Generic;

namespace AspNetCoreMvcExample.Models
{
    public class PokerHandModel
    {
        public IEnumerable<CardModel> Cards { get; set; } 
    }
}
