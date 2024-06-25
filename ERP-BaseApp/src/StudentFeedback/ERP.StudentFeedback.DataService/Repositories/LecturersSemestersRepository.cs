using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.StudentFeedback.Core.Interfaces;
using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.DataService.Repositories
{
    public class LecturersSemestersRepository : GenericRepository<LecturersSemesters>, ILecturersSemestersRepository
    {
        public LecturersSemestersRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }


        public async Task<IEnumerable<LecturersSemesters>> GetOneLecturersSemestersAsync(Guid lecturerId)
        {
            try
            {
                return await _dbSet
                    .Where(l => l.LecturerId == lecturerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetOneLecturersSemestersAsync function error", typeof(LecturersSemestersRepository));
                return Enumerable.Empty<LecturersSemesters>();
            }


        }

        public override async Task<IEnumerable<LecturersSemesters>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(LecturersSemestersRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(LecturersSemestersRepository));
                throw;

            }
        }
    }
}
