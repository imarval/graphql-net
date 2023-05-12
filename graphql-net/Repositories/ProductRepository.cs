using graphql_net.Data;
using graphql_net.Entities;
using MongoDB.Driver;

namespace graphql_net.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ICatalogContext catalogContext) : base(catalogContext) { }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string id)
    {
        var filter = Builders<Product>.Filter.Eq(_ => _.CategoryId, id);
        return await this.collection.Find(filter).ToListAsync();
    }
}