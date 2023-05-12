using graphql_net.Entities;
using graphql_net.Repositories;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_net.Queries;

[ExtendObjectType(Name = "Query")]
public class CategoryQuery
{
    public Task<IEnumerable<Category>> GetCategoriesAsync(
        [Service] ICategoryRepository productRepository) => productRepository.GetAllAsync();

    public Task<Category> GetCategoryAsync(
        string id, 
        [Service] ICategoryRepository productRepository) => productRepository.GetByIdAsync(id);
}