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
        private readonly IDictionary<int, IPromotion> _activePromos = new Dictionary<int, IPromotion>();
        public IDictionary<int, IPromotion> ActivePromotions => _activePromos;

        int MaxKey() => _activePromos.Count > 0 ? _activePromos.Keys.Max() : 0;

        public void RemoveFromStore(int promoId)
        {
            if (!_activePromos.Keys.Any(a => a == promoId))
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            _activePromos.Remove(promoId);
        }


        public void AddToStore(IPromotion promos)
        {
            if (promos == null)
                throw new MhackExc(AppConstants.INVALID_INPUT) { Type = ErrorStatus.ValidationFail };

            var lastKey = MaxKey();
            int newKey = lastKey + 1;
            _activePromos.Add(newKey, promos);

        }

        public void Clear() => _activePromos.Clear();

    }
}
