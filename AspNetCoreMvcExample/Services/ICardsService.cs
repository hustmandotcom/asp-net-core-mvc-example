using System.Collections.Generic;

namespace AspNetCoreMvcExample.Services
{
    public interface ICardsService<out T>
    {
        IEnumerable<T> DealtCards { get; }
        void DealCards();
        T GetRandomCard();
    }
}