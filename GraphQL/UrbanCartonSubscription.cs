using GraphQL.Resolvers;
using GraphQL.Types;
using UrbanCarton.Webapi.GraphQL.Messaging.Review;
using UrbanCarton.Webapi.GraphQL.Types;

namespace UrbanCarton.Webapi.GraphQL
{
    public class UrbanCartonSubscription : ObjectGraphType
    {
        public UrbanCartonSubscription(ReviewMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "ReviewAdded",
                Type = typeof(MessageType),
                Resolver = new FuncFieldResolver<Message>(a => a.Source as Message),
                Subscriber = new EventStreamResolver<Message>(a => messageService.GetMessages())
            });
        }
    }
}
