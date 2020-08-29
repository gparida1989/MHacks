using Mhacks.Models;
using System.Collections;
using System.Collections.Generic;

namespace Mhacks.Xunit.Runner
{
    public class TestDataGenerator : IEnumerable<object[]>
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


        private readonly List<CartItem[]> _data = new List<CartItem[]> { d1, d2, d3 };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_data).GetEnumerator();
        }
    }
}
