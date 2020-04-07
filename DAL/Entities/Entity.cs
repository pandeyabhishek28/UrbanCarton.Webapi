using System.ComponentModel.DataAnnotations;

namespace UrbanCarton.Webapi.DAL.Entities
{

    public class KeyedEntity
    {
        public int Id { get; set; }
    }


    public class Entity : KeyedEntity
    {

        [StringLength(100), Required]
        public string Name { get; set; }
    }
}
