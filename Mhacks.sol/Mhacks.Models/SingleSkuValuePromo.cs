using System;
using System.Linq;

namespace Mhacks.Models
{
    public class SingleSkuValuePromo : BaseSingleFixedValuePromotion
    {
        public SingleSkuValuePromo(Promotion p)
        {
            PromoDetail = p;
        }
        public override Promotion PromoDetail { get; set; }

        public override double ApplyOnCart(Cart cart)
        {
            double total = 0d;

            var originalCartItems = cart.Items;

            var normalCartItems = cart.Items.FindAll(f => !PromoDetail.Items.Select(s => s.Item).ToList().Contains(f.Item)).ToList();
            var promoCartItems = cart.Items.FindAll(f => PromoDetail.Items.Select(s => s.Item).ToList().Contains(f.Item));

            foreach (var item in promoCartItems)
            {
                var nci = new CartItem
                {
                    Item = item.Item
                };
                var originalQuantity = cart.Items.Where(w => w.Item == nci.Item).Select(s => s.Quantity).FirstOrDefault();
                nci.Quantity = originalQuantity == 0 ? 0 : originalQuantity - item.Quantity;
                normalCartItems.Add(nci);
            }
            total += NormalCartTotal(normalCartItems);
            total += PromoDetail.PromotionPrice;
            return total;
        }
    }
}
