using graphql_net.Entities;
using graphql_net.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_net.Resolvers;

[ExtendObjectType(Name = "Product")]
public class ProductResolver
{
    public Task<IEnumerable<Product>> GetProductsAsync(
        [Parent] Category category, 
        [Service] IProductRepository productRepository) => productRepository.GetProductsByCategoryAsync(category.Id);
}