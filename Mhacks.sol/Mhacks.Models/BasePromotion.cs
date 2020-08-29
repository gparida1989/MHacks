using Mhacks.Models.Abstrations;
using Mhacks.Utils.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Mhacks.Models
{
    public abstract class BaseSingleFixedValuePromotion : IPromotion
    {
        public abstract Promotion PromoDetail { get; set; }
        public PromotionType PromotionType { get; set; } = PromotionType.FixedSingleItem;

        public abstract double ApplyOnCart(Cart cart);

        public int CompareTo(IPromotion other)
        {
            return PromoDetail.CompareTo(other.PromoDetail);
        }

        public bool IsApplicable(Cart cart)
        {
            var promo = PromoDetail.Items.FirstOrDefault();

            return cart.Items.Any(w => w.Item == promo.Item && w.Quantity >= promo.Quantity);
        }

        protected double NormalCartTotal(IList<CartItem> _cartItems)
        {
            var total = 0d;
            foreach (var item in _cartItems)
            {
                var amnt = item.Item.Price * item.Quantity;
                total += amnt;
            }
            return total;
        }

    }
    public abstract class BaseMixedValuePromotion : IPromotion
    {
        public abstract Promotion PromoDetail { get; set; }
        public PromotionType PromotionType { get; set; } = PromotionType.FixedDoubleItem;

        public abstract double ApplyOnCart(Cart cart);
        public int CompareTo(IPromotion other)
        {
            return PromoDetail.CompareTo(other.PromoDetail);
        }
        protected double NormalCartTotal(IList<CartItem> _cartItems)
        {
            var total = 0d;
            foreach (var item in _cartItems)
            {
                var amnt = item.Item.Price * item.Quantity;
                total += amnt;
            }
            return total;
        }
        public bool IsApplicable(Cart cart)
        {
            bool matched = false;
            foreach (var promo in PromoDetail.Items)
            {
                matched= cart.Items.Any(w => w.Item == promo.Item && w.Quantity >= promo.Quantity);

            }
            return matched;
        }
    }
}
