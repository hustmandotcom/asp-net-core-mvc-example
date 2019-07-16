using System.Collections.Generic;
using AspNetCoreMvcExample.Models;

namespace AspNetCoreMvcExample.Services
{
    public interface IRankService<in T>
    {
        Rank GetRank(IEnumerable<T> cards);
    }
}