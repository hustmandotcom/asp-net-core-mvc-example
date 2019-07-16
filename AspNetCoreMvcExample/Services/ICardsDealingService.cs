using System.Collections.Generic;

namespace AspNetCoreMvcExample.Services
{
    public interface ICardsDealingService<T>
    {
        IEnumerable<T> DealtCards { get; }
        void DealCards();
        void SetCards(IEnumerable<T> cards);
    }
}