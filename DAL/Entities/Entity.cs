using System.ComponentModel.DataAnnotations;

namespace UrbanCarton.Webapi.DAL.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }
    }
}
