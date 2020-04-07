using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanCarton.Webapi.DAL.Entities
{

    public class Product : Entity
    {
        public ProductType Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public DateTimeOffset IntroducedAt { get; set; }

        [StringLength(100)]
        public string PhotoFileName { get; set; }

        public List<ProductReview> ProductReviews { get; set; }
    }
}
