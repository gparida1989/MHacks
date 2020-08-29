using System.Collections.Generic;

namespace Mhacks.Models.Abstrations
{
    public interface ISkuStoreManager
    {
        void AddToStore(SKU sku);

        void RemoveFromStore(SKU sku);
        void Clear();

        IList<SKU> SKUs { get; }
    }
}
