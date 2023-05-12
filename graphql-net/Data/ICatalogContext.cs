using graphql_net.Entities;
using MongoDB.Driver;

namespace graphql_net.Data;

public interface ICatalogContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}