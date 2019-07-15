using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcExample.Models
{
    public enum Suit
    {
        [Description("S")] Spade,
        [Description("H")] Heart,
        [Description("D")] Diamond,
        [Description("C")] Club,
    }
}