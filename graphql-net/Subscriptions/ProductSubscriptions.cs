using graphql_net.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace graphql_net.Subscriptions;

[ExtendObjectType(Name = "Subscription")]
public class ProductSubscriptions
{
    [Subscribe]
    [Topic]
    public Task<Product> OnCreateAsync([EventMessage] Product product) =>
        Task.FromResult(product);

    [Subscribe]
    [Topic]
    public Task<string> OnRemoveAsync([EventMessage] string productId) =>
        Task.FromResult(productId);
}