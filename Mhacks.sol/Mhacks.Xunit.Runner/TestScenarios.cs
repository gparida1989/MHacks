using Mhacks.Models;

namespace Mhacks.Xunit.Runner
{
    public class TestData
    {
        public CartItem[] CartItems { get; set; }
        public double ExpectedTotalAmount { get; set; }
    }
    public class TestScenarios
    {
        static CartItem[] d1 = new CartItem[]
        {
            new CartItem() { Item= new SKU() { Price = 50, SkuId = 'A' }, Quantity=1 } ,
            new CartItem() { Item= new SKU() { Price = 30, SkuId = 'B' }, Quantity=1 } ,
            new CartItem() { Item= new SKU() { Price = 20, SkuId = 'C' }, Quantity=1 }
        };

        static CartItem[] d2 = new CartItem[]
        {
            new CartItem() { Item= new SKU() { Price = 50, SkuId = 'A' }, Quantity=5 } ,
            new CartItem() { Item= new SKU() { Price = 30, SkuId = 'B' }, Quantity=5 } ,
            new CartItem() { Item= new SKU() { Price = 20, SkuId = 'C' }, Quantity=1 }
        };

        static CartItem[] d3 = new CartItem[]
        {
            new CartItem() { Item= new SKU() { Price = 50, SkuId = 'A' }, Quantity=3 } ,
            new CartItem() { Item= new SKU() { Price = 30, SkuId = 'B' }, Quantity=5 } ,
            new CartItem() { Item= new SKU() { Price = 20, SkuId = 'C' }, Quantity=1 },
            new CartItem() { Item= new SKU() { Price = 15, SkuId = 'D' }, Quantity=1 }
        };

        public static TestData Scenario1 = new TestData { CartItems = d1, ExpectedTotalAmount = 100 };
        public static TestData Scenario2 = new TestData { CartItems = d2, ExpectedTotalAmount = 400 };
        public static TestData Scenario3 = new TestData { CartItems = d3, ExpectedTotalAmount = 315 };
    }
}
