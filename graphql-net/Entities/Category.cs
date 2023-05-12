using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace graphql_net.Entities;

public class Category: BaseEntity
{
    public string Description { get; set; }
}