using graphql_net.Entities;
using graphql_net.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace graphql_net.Mutations;

[ExtendObjectType(Name = "Mutation")]
public class ProductMutation
{
    public async Task<Product> CreateProductAsync(Product product,
        [Service] IProductRepository productRepository,
        [Service] ITopicEventSender eventSender)
    {
        var result = await productRepository.InsertAsync(product);

        await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnCreateAsync), result);

        return result;
    }

    public async Task<bool> RemoveProductAsync(string id,
        [Service] IProductRepository productRepository,
        [Service] ITopicEventSender eventSender)
    {
        var result = await productRepository.RemoveAsync(id);

        if (result)
        {
            await eventSender.SendAsync(nameof(Subscriptions.ProductSubscriptions.OnRemoveAsync), id);
        }

        return result;
    }
}