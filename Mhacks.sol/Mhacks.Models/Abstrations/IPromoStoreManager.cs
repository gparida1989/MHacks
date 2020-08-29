using System.Collections.Generic;

namespace Mhacks.Models.Abstrations
{
    public interface IPromoStoreManager
    {
        void AddToStore(IList<PromoItem> promoItem, double promoPrice);
        void AddToStore(IList<Promotion> promos);
        void AddToStore(Promotion promos);

        void RemoveFromStore(int promoId);
        void RemoveFromStore(SKU sku);

        void Clear();

        IDictionary<int, Promotion> ActivePromotions { get; }
    }
}
