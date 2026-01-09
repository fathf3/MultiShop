using MongoDB.Driver;

namespace MultiShop.Catalog.Repositories
{
    public interface IMongoRepository<TEntity>
    {
        IMongoCollection<TEntity> Collection { get; }
    }
}
