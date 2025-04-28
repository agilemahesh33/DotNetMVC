
using Microsoft.EntityFrameworkCore;
using WebAPIGenericRepoDP.Data;

namespace WebAPIGenericRepoDP.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(MyDbContext dbContext)
        {
            this.dbSet = dbContext.Set<T>();
            this.dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;            
        }
        public async Task DeleteAsync(T entity)
        {         
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
