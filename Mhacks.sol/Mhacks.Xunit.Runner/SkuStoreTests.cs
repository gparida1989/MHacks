using Mhacks.Models.Abstrations;
using Mhacks.Store;
using Xunit;

namespace Mhacks.Xunit.Runner
{
    public class SkuStoreTests
    {
        ISkuStoreManager _store;
        public SkuStoreTests()
        {
            _store = new SkuStoreManager();
        }

        [Fact]
        public void TestAdd()
        {
            Assert.Empty(_store.SKUs);

            _store.AddToStore(new Models.SKU() { Price = 20, SkuId = 'X' });

            Assert.Single(_store.SKUs);
            _store.Clear();

        }


    }
}
