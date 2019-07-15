using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_core_mvc_example.Models
{
    public class PokerHandModel
    {
        public IEnumerable<CardModel> Cards { get; set; } 
    }
}
