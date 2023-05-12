using graphql_net.Data;
using graphql_net.Entities;

namespace graphql_net.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ICatalogContext catalogContext) : base(catalogContext) { }
}