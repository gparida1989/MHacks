using Mhacks.Utils.Enums;
using System;

namespace Mhacks.Models.Abstrations
{
    public interface IPromotion: IComparable<IPromotion>
    {
        Promotion PromoDetail { get; set; }
        PromotionType PromotionType { get; set; }

        bool IsApplicable(Cart cart);
        double ApplyOnCart(Cart cart);
    }
}
