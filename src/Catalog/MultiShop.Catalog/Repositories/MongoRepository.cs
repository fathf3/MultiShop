using MongoDB.Driver;
using MultiShop.Catalog.Attributes;
using MultiShop.Catalog.Settings;
using System.Reflection;

namespace MultiShop.Catalog.Repositories
{
    using MongoDB.Driver;
    using MultiShop.Catalog.Entities;
    using System.Reflection;

    public class MongoRepository<TEntity> : IMongoRepository<TEntity>
        where TEntity : BaseEntity
    {
        public IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(IMongoDatabase database)
        {
            var collectionName = GetCollectionName();
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        private static string GetCollectionName()
        {
            var attribute = typeof(TEntity)
                .GetCustomAttribute<BsonCollectionAttribute>();

            return attribute?.CollectionName ?? typeof(TEntity).Name;
        }
    }


}