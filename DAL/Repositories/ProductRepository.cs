using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.DAL.Repositories
{
    public class ProductRepository
    {
        private readonly UrbanCartonDbContext _dbContext;

        public ProductRepository(UrbanCartonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.AsNoTracking();
        }

        public async Task<Product> GetOneAsync(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
