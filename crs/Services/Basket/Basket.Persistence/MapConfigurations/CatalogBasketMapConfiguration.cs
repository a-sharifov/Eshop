using MongoDB.Bson.Serialization;

namespace Basket.Persistence.MapConfigurations;

internal sealed class CatalogBasketMapConfiguration : IMapConfiguration<CatalogBasket>
{
    //public void Configure()
    //{
    //    BsonClassMap.RegisterClassMap<CatalogBasket>(map =>
    //    {
    //        map.AutoMap();
    //        map.SetIgnoreExtraElements(true);
    //        map.MapIdProperty(x => x.Id);
    //        map.MapProperty(x => x.BasketId).SetElementName("BasketId");
    //        map.MapProperty(x => x.ProductId).SetElementName("ProductId");
    //        map.MapProperty(x => x.Quantity).SetElementName("Quantity");
    //    });
    //}

    public void Configure(BsonClassMap<CatalogBasket> map)
    {
        map.AutoMap();
        map.SetIgnoreExtraElements(true);
        map.MapIdProperty(x => x.Id);
        map.MapProperty(x => x.BasketId).SetElementName("BasketId");
        map.MapProperty(x => x.ProductId).SetElementName("ProductId");
        map.MapProperty(x => x.Quantity).SetElementName("Quantity");
    }
}
