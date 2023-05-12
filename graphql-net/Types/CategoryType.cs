using graphql_net.Entities;
using graphql_net.Resolvers;
using HotChocolate.Types;

namespace graphql_net.Types;

public class CategoryType: ObjectType<Category>
{
    protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
    {
        descriptor.Field(_ => _.Id);
        descriptor.Field(_ => _.Description);
        descriptor.Field<ProductResolver>(_ => _.GetProductsAsync(default, default))
            .Name("products");
    }
}