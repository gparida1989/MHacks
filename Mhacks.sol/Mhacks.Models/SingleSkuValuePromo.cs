using System;

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
            throw new NotImplementedException();
        }
    }
}
