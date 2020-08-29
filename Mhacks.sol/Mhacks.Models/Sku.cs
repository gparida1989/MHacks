namespace Mhacks.Models
{
    public class SKU
    {
        public char SkuId { get; set; }
        public double Price { get; set; }
        public override int GetHashCode()
        {
            return SkuId;
        }
        public override bool Equals(object obj)
        {
            SKU o = obj as SKU;

            return this.SkuId == o.SkuId;
        }
    }
}
