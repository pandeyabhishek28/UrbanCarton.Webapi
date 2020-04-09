using GraphQL.Types;
using UrbanCarton.Webapi.DAL.Repositories;
using UrbanCarton.Webapi.GraphQL.Types;

namespace UrbanCarton.Webapi.GraphQL
{
    public class UrbanCartonQuery : ObjectGraphType
    {
        public UrbanCartonQuery(ProductRepository productRepository,
            ProductReviewRepository productReviewRepository)
        {
            Field<ListGraphType<ProductType>>("products",
                resolve: context => productRepository.GetAllAsync());

            Field<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                 {
                     var id = context.GetArgument<int>("id");
                     return productRepository.GetOneAsync(id);
                 });

            Field<ListGraphType<ProductReviewType>>("reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "productId"
                }),
                resolve: context =>
                 {
                     var id = context.GetArgument<int>("productId");
                     return productReviewRepository.GetForProduct(id);
                 });

            Field<ListGraphType<ProductReviewType>>("allReviews",
                resolve: context =>
                {
                    return productReviewRepository.GetAll();
                });
        }
    }
}
