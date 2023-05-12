using graphql_net.Data;
using graphql_net.Entities;
using MongoDB.Driver;

namespace graphql_net.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly IMongoCollection<T> collection;

    public BaseRepository(ICatalogContext catalogContext)
    {
        if (catalogContext == null)
        {
            throw new ArgumentNullException(nameof(catalogContext));
        }

        this.collection = catalogContext.GetCollection<T>(typeof(T).Name);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await this.collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(_ => _.Id, id);

        return await this.collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> InsertAsync(T entity)
    {
        await this.collection.InsertOneAsync(entity);

        return entity;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var result = await this.collection.DeleteOneAsync(Builders<T>.Filter.Eq(_ => _.Id, id));

        return result.DeletedCount > 0;
    }
}