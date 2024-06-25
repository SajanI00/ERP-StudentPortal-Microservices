using ERP.StudentFeedback.Core.Entity;
using ERP.StudentFeedback.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.StudentFeedback.DataService.Repositories
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }


        //public async Task<IEnumerable<Feedback>> GetStudentFeedbackAsync(Guid studentId)
        //{
        //    try
        //    {
        //        return await _dbSet
        //            .Include(a => a.FeedbackGroup)
        //            .Where(a => a.FeedbackGroup != null && a.FeedbackGroup.StudentIds.Contains(studentId))
        //            .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} GetStudentFeedbackAsync function error", typeof(FeedbackRepository));
        //        return Enumerable.Empty<Feedback>();
        //    }
        //}

        //public async Task<IEnumerable<Feedback>> GetStudentFeedbackAsync(Guid studentId)
        //{
        //    try
        //    {
        //        return await _dbSet
        //           .Where(s => s.StudentId == studentId)
        //            .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} GetStudentFeedbackAsync function error", typeof(FeedbackRepository));
        //        return Enumerable.Empty<Feedback>();
        //    }
        //}

        //public async Task<IEnumerable<Feedback>> GetFeedbackGroupFeedbackAsync(Guid feedbackGroupId)
        //{
        //    try
        //    {
        //        return await _dbSet
        //           .Where(ag => ag.FeedbackGroupId == feedbackGroupId)
        //           .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} GetFeedbackGroupFeedbackAsync function error", typeof(FeedbackRepository));
        //        return Enumerable.Empty<Feedback>();
        //    }
        //}

        public async Task<IEnumerable<Feedback>> GetLecturerFeedbackAsync(Guid lecturerId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.LecturerId == lecturerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetLecturerFeedbackAsync function error", typeof(FeedbackRepository));
                return Enumerable.Empty<Feedback>();
            }
        }


        public override async Task<IEnumerable<Feedback>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(FeedbackRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(FeedbackRepository));
                throw;

            }
        }

    }
}
