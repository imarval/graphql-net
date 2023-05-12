using graphql_net.Entities;
using graphql_net.Repositories;
using HotChocolate;

namespace graphql_net.Queries;

public class Query
{
    public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
        productRepository.GetAllAsync();

    public Task<Product> GetProductById(string id, [Service] IProductRepository productRepository) =>
        productRepository.GetByIdAsync(id);
}