using GraphQL;
using GraphQL.Types;

namespace UrbanCarton.Webapi.GraphQL
{
    public class UrbanCartonSchema : Schema
    {
        public UrbanCartonSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<UrbanCartonQuery>();
            Mutation = dependencyResolver.Resolve<UrbanCartonMutation>();
            Subscription = dependencyResolver.Resolve<UrbanCartonSubscription>();
        }
    }
}
