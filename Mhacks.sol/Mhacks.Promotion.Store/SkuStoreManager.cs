using Mhacks.Models;
using Mhacks.Models.Abstrations;
using Mhacks.Utils.Constants;
using System.Collections.Generic;

namespace Mhacks.Store
{
    public class SkuStoreManager : ISkuStoreManager
    {
        private readonly IList<SKU> _skus= new List<SKU>();
        public IList<SKU> SKUs => _skus;

        public void AddToStore(SKU sku)
        {
            if (SKUs.Contains(sku)) throw new MhackExc(AppConstants.INVALID_INPUT) { Type = Utils.Enums.ErrorStatus.ValidationFail };

            SKUs.Add(sku);
        }

        public void Clear() => _skus.Clear();
       

        public void RemoveFromStore(SKU sku)
        {
            SKUs.Remove(sku);
        }
    }
}
