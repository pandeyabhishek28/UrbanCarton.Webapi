using GraphQL.Types;
using UrbanCarton.Webapi.GraphQL.Messaging.Review;

namespace UrbanCarton.Webapi.GraphQL.Types
{
    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Field(t => t.ProductId);
            Field(t => t.Title);
            Field(t => t.Comments);
        }
    }
}
