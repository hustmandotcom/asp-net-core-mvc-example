using System;
using AspNetCoreMvcExample.Extensions;

namespace AspNetCoreMvcExample.Models
{
    public class CardModel
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }

        public override string ToString()
        {
            var suit = Suit.GetDescription();
            var face = Face.GetDescription();
            return $"{face}{suit}";
        }
    }
}
