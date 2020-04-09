using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.DAL.Repositories
{
    public class ProductReviewRepository
    {
        private readonly UrbanCartonDbContext _dbContext;

        public ProductReviewRepository(UrbanCartonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductReview> GetForProduct(int productId)
        {
            return _dbContext.ProductReviews.Where(pr => pr.ProductId == productId).ToList();
        }

        public ILookup<int, ProductReview> GetForProducts(IEnumerable<int> productIds)
        {
            var reviews = _dbContext.ProductReviews.Where(pr =>
           productIds.Contains(pr.ProductId)).ToList();
            return reviews.ToLookup(r => r.ProductId);
        }

        public async Task<ILookup<int, ProductReview>> GetForProductsAsync(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.ProductReviews.Where(pr =>
                            productIds.Contains(pr.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }
        public IEnumerable<ProductReview> GetAll()
        {
            return _dbContext.ProductReviews.AsNoTracking();
        }

        public async Task<ProductReview> AddReview(ProductReview review)
        {
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}
