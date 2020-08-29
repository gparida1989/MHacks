using System.Collections.Generic;

namespace Mhacks.Models
{
    public class Promotion
    {
        public IList<PromoItem> Items { get; set; }
        public double PromotionPrice { get; set; }
    }
}
