using GraphQL.Types;
using UrbanCarton.Webapi.DAL.Entities;
using UrbanCarton.Webapi.DAL.Repositories;
using UrbanCarton.Webapi.GraphQL.Messaging.Review;
using UrbanCarton.Webapi.GraphQL.Types;

namespace UrbanCarton.Webapi.GraphQL
{
    public class UrbanCartonMutation : ObjectGraphType
    {
        public UrbanCartonMutation(ProductReviewRepository productReviewRepository,
            ReviewMessageService reviewMessageService)
        {
            FieldAsync<ProductReviewType>("createReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReviewInputType>>
                {
                    Name = "review"
                }),
                resolve: async context =>
                {
                    var review = context.GetArgument<ProductReview>("review");
                    await productReviewRepository.AddReview(review);
                    reviewMessageService.AddReviewAddedMessage(review);
                    return review;
                });
        }
    }
}
