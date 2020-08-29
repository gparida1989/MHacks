using System;

namespace Mhacks.Models
{
    public class MixedSkuValuePromo : BaseSingleFixedValuePromotion
    {
        public MixedSkuValuePromo(Promotion p)
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
