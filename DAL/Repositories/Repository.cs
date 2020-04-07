using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanCarton.Webapi.DAL.Entities;

namespace UrbanCarton.Webapi.DAL.Repositories
{
    public class Repository<T> where T : KeyedEntity
    {
        private readonly UrbanCartonDbContext _dbContext;

        public Repository(UrbanCartonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetOne(int id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
