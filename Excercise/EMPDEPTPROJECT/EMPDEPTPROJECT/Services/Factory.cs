using EMPDEPTPROJECT.Data;
using EMPDEPTPROJECT.Interfaces;
using EMPDEPTPROJECT.Repositories;

namespace EMPDEPTPROJECT.Services
{
    public class Factory : IFactory
    {
        private readonly AppDbContext _context;

        public Factory(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
    }

}
