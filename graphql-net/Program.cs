using graphql_net.Configurations;
using graphql_net.Data;
using graphql_net.Mutations;
using graphql_net.Queries;
using graphql_net.Repositories;
using graphql_net.Resolvers;
using graphql_net.Subscriptions;
using graphql_net.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddSingleton(builder.Configuration.Get<ApiConfiguration>().MongoDbConfiguration);

// Repositories
builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<ProductQuery>()
        .AddTypeExtension<CategoryQuery>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<ProductMutation>()
        .AddTypeExtension<CategoryMutation>()
    .AddSubscriptionType(d => d.Name("Subscription"))
        .AddTypeExtension<ProductSubscriptions>()
    .AddType<ProductType>()
    .AddType<CategoryResolver>()
    .AddType<CategoryType>()
    .AddType<ProductResolver>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});

app.Run();