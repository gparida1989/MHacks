using System.Collections.Generic;

namespace Mhacks.Models.Abstrations
{
    public interface IPromoStoreManager
    {
        void AddToStore(IPromotion promos);

        void RemoveFromStore(int promoId);

        void Clear();

        IDictionary<int, IPromotion> ActivePromotions { get; }
    }
}
