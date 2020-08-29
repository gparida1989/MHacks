using Mhacks.Models;
using Mhacks.Models.Abstrations;
using Mhacks.Store;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mhacks.Xunit.Runner
{
    public class PromoCalcTest
    {
        IPromoStoreManager _pstore;
        ISkuStoreManager _sstore;
        Cart _cart;

        [Fact]
        public void TestSetup()
        {
            _pstore = StoreSetupHelper.PromoStore;
            _sstore = StoreSetupHelper.SkuStore;

            Assert.NotEmpty(_pstore.ActivePromotions);
            Assert.NotEmpty(_sstore.SKUs);

            Assert.Equal(3, _pstore.ActivePromotions.Count);
            Assert.Equal(4, _sstore.SKUs.Count);

            Assert.True( _sstore.SKUs[0].Equals(_pstore.ActivePromotions.Values.First().Items[0].Item));

        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void TestScenario(params CartItem[] cartItems)
        {
            _cart = new Cart();
            _cart.Items.AddRange(cartItems);

            var t = _cart.Items;
        }

    }
}
