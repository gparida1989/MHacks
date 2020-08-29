using Mhacks.Models;
using Mhacks.Models.Abstrations;
using Mhacks.Store;
using System.Linq;

namespace Mhacks.Cart.Engine
{
    public class CheckoutProcess : ICartValueCalculator
    {
        IPromoStoreManager _pstore;
        ISkuStoreManager _sstore;
        Models.Cart _cart;

        public CheckoutProcess(Models.Cart cart)
        {
            _pstore = StoreSetupHelper.PromoStore;
            _sstore = StoreSetupHelper.SkuStore;
            _cart = cart;
        }

        public double GetTotalCartValue()
        {
            double total = 0d;
            void normalTotal()
            {
                foreach (var item in _cart.Items)
                {
                    var amnt = item.Item.Price * item.Quantity;
                    total += amnt;
                }
                
            }
            void promoTotal(int promoId)
            {
                var appliedPromo = _pstore.ActivePromotions[promoId];

                total += appliedPromo.ApplyOnCart(_cart);
            }
            if (_cart.Items.Count == 0) return 0d;

            
            if (_pstore.ActivePromotions.Count == 0)
            {
                normalTotal();
            }
            else
            {
                var orderedPromos = _pstore.ActivePromotions.OrderBy(o => o.Value);
                var appliedPromoId = -1;
                foreach (var promo in orderedPromos)
                {
                    if (promo.Value.IsApplicable(_cart))
                    {
                        appliedPromoId = promo.Key;
                        break;
                    }
                }

                if(appliedPromoId == -1) normalTotal();
                else
                {
                    promoTotal(appliedPromoId);
                }
            }

            return total;
        }

    }
}
