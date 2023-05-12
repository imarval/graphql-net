using graphql_net.Entities;
using graphql_net.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_net.Queries;

[ExtendObjectType(Name = "Query")]
public class ProductQuery
{
    
    public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
        productRepository.GetAllAsync();

    public Task<Product> GetProductAsync(string id, [Service] IProductRepository productRepository) =>
        productRepository.GetByIdAsync(id);
}