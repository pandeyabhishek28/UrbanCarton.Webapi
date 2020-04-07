using System.ComponentModel.DataAnnotations;

namespace UrbanCarton.Webapi.DAL.Entities
{
    public class ProductReview : KeyedEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [StringLength(200), Required]
        public string Title { get; set; }
        public string Review { get; set; }
    }
}
