using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace graphql_net.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string CategoryId { get; set; }
}