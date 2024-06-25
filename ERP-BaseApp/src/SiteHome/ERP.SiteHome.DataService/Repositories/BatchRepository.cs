using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.SiteHome.DataService.Repositories
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        public BatchRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Batch>> GetDepartmentBatchAsync(Guid departmentId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.DepartmentId == departmentId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetDepartmentBatchAsync function error", typeof(BatchRepository));
                return Enumerable.Empty<Batch>();
            }
        }

        public override async Task<IEnumerable<Batch>> GetAll()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(BatchRepository));
                throw;

            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                //get by id
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0; 
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(BatchRepository));
                throw;

            }
        }

    }
}
