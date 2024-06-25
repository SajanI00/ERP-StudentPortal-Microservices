using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ERP.SiteHome.DataService.Repositories
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Semester>> GetBatchSemesterAsync(Guid batchId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.BatchId == batchId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetBatchSemesterAsync function error", typeof(SemesterRepository));
                return Enumerable.Empty<Semester>();
            }
        }

        public override async Task<IEnumerable<Semester>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(SemesterRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(SemesterRepository));
                throw;

            }
        }
    }
}
