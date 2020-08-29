using System;
using System.Collections.Generic;

namespace Mhacks.Models
{
    public class Promotion : IComparable<Promotion>
    {
        public IList<PromoItem> Items { get; set; }
        public double PromotionPrice { get; set; }

        public int CompareTo(Promotion other)
        {
            return other.PromotionPrice > PromotionPrice ? 1 : other.PromotionPrice < PromotionPrice ? -1 : 0;
        }
    }
}
