using Mhacks.Models;
using Mhacks.Models.Abstrations;
using System.Collections.Generic;

namespace Mhacks.Store
{
    public sealed class StoreSetupHelper
    {
        private StoreSetupHelper()
        {
        }

        private static ISkuStoreManager _skuStore;
        private static IPromoStoreManager _promoStore;

        public static ISkuStoreManager SkuStore
        {
            get
            {
                if (_skuStore == null)
                {
                    _skuStore = new SkuStoreManager();
                    _skuStore.AddToStore(new SKU() { Price = 50, SkuId = 'A' });
                    _skuStore.AddToStore(new SKU() { Price = 30, SkuId = 'B' });
                    _skuStore.AddToStore(new SKU() { Price = 20, SkuId = 'C' });
                    _skuStore.AddToStore(new SKU() { Price = 15, SkuId = 'D' });
                }

                return _skuStore;
            }
        }

        public static IPromoStoreManager PromoStore
        {
            get
            {
                if (_promoStore == null)
                {
                    _promoStore = new PromoStoreManager();

                    var promo1 = new Promotion
                    {
                        PromotionPrice = 130,
                        Items = new List<PromoItem>()
                        {
                            new PromoItem(){ Item = new SKU() { Price = 50, SkuId = 'A' }, Quantity=3}
                        }
                    };

                    var singleskupromo1 = new SingleSkuValuePromo(promo1);
                    _promoStore.AddToStore(singleskupromo1);

                    var promo2 = new Promotion
                    {
                        PromotionPrice = 45,
                        Items = new List<PromoItem>()
                        {
                            new PromoItem(){ Item = new SKU() { Price = 30, SkuId = 'B' }, Quantity=2}
                        }
                    };

                    var singleskupromo2 = new SingleSkuValuePromo(promo2);
                    _promoStore.AddToStore(singleskupromo2);

                    var promo3 = new Promotion
                    {
                        PromotionPrice = 30,
                        Items = new List<PromoItem>()
                        {
                            new PromoItem(){ Item = new SKU() { Price = 20, SkuId = 'C' }, Quantity=1},
                            new PromoItem(){ Item = new SKU() { Price = 15, SkuId = 'D' }, Quantity=1}
                        }
                    };
                    var mixedskupromo1 = new MixedSkuValuePromo(promo3);
                    _promoStore.AddToStore(mixedskupromo1);

                }

                return _promoStore;
            }
        }

    }
}
