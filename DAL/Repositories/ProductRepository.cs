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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetOne(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
