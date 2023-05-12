using graphql_net.Entities;
using graphql_net.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_net.Resolvers;

[ExtendObjectType(Name = "Category")]
public class CategoryResolver
{
    public Task<Category> GetCategoryAsync(
        [Parent] Product product, 
        [Service] ICategoryRepository categoryRepository) => categoryRepository.GetByIdAsync(product.CategoryId);
}