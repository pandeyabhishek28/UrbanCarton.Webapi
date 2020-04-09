using Microsoft.EntityFrameworkCore;
using UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.DAL
{
    public class UrbanCartonDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        public UrbanCartonDbContext(DbContextOptions<UrbanCartonDbContext> options) : base(options)
        {

        }
    }
}
