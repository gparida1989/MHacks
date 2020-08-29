using Mhacks.Utils.Enums;

namespace Mhacks.Models.Abstrations
{
    public interface IPromotion
    {
        Promotion PromoDetail { get; set; }
        PromotionType PromotionType { get; set; }
        double ApplyOnCart(Cart cart);
    }
}
