using GraphQL.Types;
using Entities = UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.GraphQL.Types
{
    public class ProductTypeType : ObjectGraphType<Entities.ProductType>
    {
        public ProductTypeType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}
