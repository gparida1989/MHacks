using Mhacks.Cart.Engine;
using Mhacks.Models;
using Mhacks.Models.Abstrations;
using Mhacks.Store;
using System.Linq;
using Xunit;

namespace Mhacks.Xunit.Runner
{
    public class PromoCalcTest
    {
        IPromoStoreManager _pstore;
        ISkuStoreManager _sstore;
        ICartValueCalculator _cartProcess;
        Models.Cart _cart;

        public PromoCalcTest()
        {
            _cartProcess = new CheckoutProcess();
        }

        [Fact]
        public void TestSetup()
        {
            _pstore = StoreSetupHelper.PromoStore;
            _sstore = StoreSetupHelper.SkuStore;

            Assert.NotEmpty(_pstore.ActivePromotions);
            Assert.NotEmpty(_sstore.SKUs);

            Assert.Equal(3, _pstore.ActivePromotions.Count);
            Assert.Equal(4, _sstore.SKUs.Count);

            Assert.True(_sstore.SKUs[0].Equals(_pstore.ActivePromotions.Values.First().Items[0].Item));

        }

        [Theory]
        [ClassData(typeof(CartTestData))]
        public void TestScenario(CartItem[] cartItems, double expectedCartTotalAmount)
        {
            _cart = new Models.Cart();
            _cart.Items.AddRange(cartItems);

            var total = _cartProcess.GetTotalCartValue(_cart);

            Assert.Equal(expectedCartTotalAmount, total);
        }

    }
}
