using graphql_net.Entities;

namespace graphql_net.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task<T> InsertAsync(T entity);
    Task<bool> RemoveAsync(string id);
}