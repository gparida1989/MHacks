using Mhacks.Models.Abstrations;
using Mhacks.Utils.Enums;

namespace Mhacks.Models
{
    public abstract class BaseSingleFixedValuePromotion : IPromotion
    {
        public abstract Promotion PromoDetail { get; set; }
        public PromotionType PromotionType { get; set; } = PromotionType.FixedSingleItem;

        public abstract double ApplyOnCart(Cart cart);

    }
    public abstract class BaseMixedValuePromotion : IPromotion
    {
        public abstract Promotion PromoDetail { get; set; }
        public PromotionType PromotionType { get; set; } = PromotionType.FixedDoubleItem;

        public abstract double ApplyOnCart(Cart cart);

    }
}
