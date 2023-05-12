using graphql_net.Configurations;
using graphql_net.Entities;
using MongoDB.Driver;

namespace graphql_net.Data;

public class CatalogContext: ICatalogContext
{
    private readonly IMongoDatabase database;

    public CatalogContext(MongoDbConfiguration mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.ConnectionString);

        this.database = client.GetDatabase(mongoDbConfiguration.Database);

        CatalogContextSeed.SeedData(this.database);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return this.database.GetCollection<T>(name);
    }
}