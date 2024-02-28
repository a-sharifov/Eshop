using MongoDB.Bson.Serialization;

namespace Basket.Persistence.MapConfigurations.Abstractions;

public interface IMapConfiguration<TEntity>
{
    public void Configure(BsonClassMap<TEntity> bsonClassMap);
}
