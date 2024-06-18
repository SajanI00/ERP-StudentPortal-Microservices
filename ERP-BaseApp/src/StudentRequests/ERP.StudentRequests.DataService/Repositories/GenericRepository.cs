using ERP.StudentRequests.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.StudentRequests.DataService.Data;

namespace ERP.StudentRequests.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ILogger _logger;
        protected AppDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context, ILogger logger)
        {
            _logger = logger;
            _context = context;

            _dbSet = context.Set<T>();
        }

        public virtual Task<IEnumerable<T>> GetAll()         //Not Implemented
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)          //Not Implemented
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Update(T entity)        //Not Implemented
        {
            throw new NotImplementedException();
        }
    }
}
