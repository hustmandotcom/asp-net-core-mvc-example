using System.Collections.Generic;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public interface ICardsRankingService<in T, out TT>
    {
        TT GetRank(IEnumerable<T> cards);
    }
}