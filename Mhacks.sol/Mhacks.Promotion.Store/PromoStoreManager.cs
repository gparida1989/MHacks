using Mhacks.Models;
using Mhacks.Models.Abstrations;
using Mhacks.Utils.Constants;
using Mhacks.Utils.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Mhacks.Store
{
    public class PromoStoreManager : IPromoStoreManager
    {
        private readonly IDictionary<int, Models.Promotion> _activePromos = new Dictionary<int, Models.Promotion>();
        public IDictionary<int, Models.Promotion> ActivePromotions => _activePromos;

        public void AddToStore(IList<PromoItem> promoItem, double promoPrice)
        {
            if (promoItem == null || promoPrice == 0)
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            var lastKey = MaxKey();
            _activePromos
                .Add(
                    lastKey + 1,
                    new Models.Promotion()
                    {
                        Items = promoItem,
                        PromotionPrice = promoPrice
                    }
                );
        }

        int MaxKey() => _activePromos.Count > 0 ?_activePromos.Keys.Max() : 0;

        public void AddToStore(IList<Models.Promotion> promos)
        {
            if (promos == null || promos.Count == 0)
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            var lastKey = MaxKey();
            foreach (var item in promos)
            {
                int newKey = lastKey + 1;
                _activePromos.Add(newKey, item);
            }
        }


        public void RemoveFromStore(int promoId)
        {
            if (!_activePromos.Keys.Any(a => a == promoId))
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            _activePromos.Remove(promoId);
        }

        public void RemoveFromStore(SKU sku)
        {
            var iDs = _activePromos.Where(s => s.Value.Items.Any(i => i.Item.SkuId == sku.SkuId))
                 .Select(q => q.Key).ToList();

            if (iDs.Count == 0)
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            iDs.ForEach(f =>
            {
                _activePromos.Remove(f);
            });

        }

        public void AddToStore(Promotion promos)
        {
            if (promos == null )
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            var lastKey = MaxKey();
            int newKey = lastKey + 1;
            _activePromos.Add(newKey, promos);
            
        }

        public void Clear() => _activePromos.Clear();
        
    }
}
