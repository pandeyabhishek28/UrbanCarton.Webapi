using GraphQL.Types;
using UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.GraphQL.Types
{
    public class ProductReviewType : ObjectGraphType<ProductReview>
    {
        public ProductReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
