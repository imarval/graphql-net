using graphql_net.Entities;

namespace graphql_net.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(string id);
}