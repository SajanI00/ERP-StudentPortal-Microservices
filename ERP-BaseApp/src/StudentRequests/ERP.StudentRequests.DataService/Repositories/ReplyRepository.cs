using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.StudentRequests.DataService.Repositories
{
    public class ReplyRepository : GenericRepository<Reply>, IReplyRepository
    {
        public ReplyRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Reply>> GetLecturerReplyAsync(Guid lecturerId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.LecturerId == lecturerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetLecturerIdReplyAsync function error", typeof(ReplyRepository));
                return Enumerable.Empty<Reply>();
            }
        }

        public async Task<IEnumerable<Reply>> GetStudentReplyAsync(Guid studentId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.StudentId == studentId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetStudentReplyAsync function error", typeof(ReplyRepository));
                return Enumerable.Empty<Reply>();
            }
        }

        public async Task<IEnumerable<Reply>> GetRequestReplyAsync(Guid requestId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.RequestId == requestId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetRequestReplyAsync function error", typeof(ReplyRepository));
                return Enumerable.Empty<Reply>();
            }
        }


        public override async Task<IEnumerable<Reply>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(ReplyRepository));
                throw;

            }
        }

    }
}
