using Mhacks.Models;
using Mhacks.Models.Abstrations;
using Mhacks.Store;
using System.Collections.Generic;
using Xunit;

namespace Mhacks.Xunit.Runner
{
    public class PromoStoreTests
    {
        IPromoStoreManager _store;
        public PromoStoreTests()
        {
            _store = new PromoStoreManager();
        }
        [Fact(DisplayName = "Should add 1 promotions.")]
        public void Test1()
        {
            var promos = new Promotion()
            {
                Items = new List<PromoItem>()
                {
                    new PromoItem(){ Item = new SKU(){ SkuId = 'A', Price=10}, Quantity=1},
                    new PromoItem(){ Item = new SKU(){ SkuId = 'B', Price=20}, Quantity = 2}
                },
                PromotionPrice = 100
            };

            Promotion nm = null;
            Assert.Equal(0, _store.ActivePromotions.Count);
            Assert.Throws<MhackExc>(() => _store.AddToStore(nm));

            _store.AddToStore(promos);

            Assert.Equal(1, _store.ActivePromotions.Count);
            _store.Clear();
        }
    }
}
