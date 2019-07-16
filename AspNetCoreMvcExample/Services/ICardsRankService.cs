using System.Collections.Generic;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public interface ICardsRankService<in T>
    {
        Rank GetRank(IEnumerable<T> cards);
    }
}