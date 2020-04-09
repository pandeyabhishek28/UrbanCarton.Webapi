using GraphQL.DataLoader;
using GraphQL.Types;
using System.Security.Claims;
using UrbanCarton.Webapi.DAL.Repositories;
using Entities = UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Entities.Product>
    {
        public ProductType(ProductReviewRepository productReviewRepository,
                        IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("The file name of the photo so the client can render it");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);

            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var user = (ClaimsPrincipal)context.UserContext;
                    var loader =
                        dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, Entities.ProductReview>(
                            "GetReviewsByProductId", productReviewRepository.GetForProductsAsync);
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
