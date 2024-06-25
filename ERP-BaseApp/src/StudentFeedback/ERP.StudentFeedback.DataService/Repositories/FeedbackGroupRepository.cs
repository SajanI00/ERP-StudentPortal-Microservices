//using ERP.StudentFeedback.Core.Entity;
//using ERP.StudentFeedback.Core.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace ERP.StudentFeedback.DataService.Repositories
//{
//    public class FeedbackGroupRepository : GenericRepository<FeedbackGroup>, IFeedbackGroupRepository
//    {
//        public FeedbackGroupRepository(AppDbContext context, ILogger logger) : base(context, logger)
//        {
//        }

//        public async Task<IEnumerable<FeedbackGroup>> GetStudentFeedbackGroupAsync(Guid studentId)
//        {
//            try
//            {
//                return await _dbSet
//                    .Include(fg => fg.FeedbackGroupStudents)
//                    .Where(fg => fg.FeedbackGroupStudents.Any(s => s.StudentId == studentId))
//                    .ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "{Repo} GetStudentFeedbackGroupsAsync function error", typeof(FeedbackGroupRepository));
//                throw;
//            }
//        }

//        public async Task<IEnumerable<FeedbackGroup>> GetLecturerFeedbackGroupAsync(Guid lecturerId)
//        {
//            try
//            {
//                return await _dbSet
//                   .Where(s => s.LecturerId == lecturerId)
//                   .ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "{Repo} GetLecturerAnnouncementGroupAsync function error", typeof(FeedbackGroupRepository));
//                return Enumerable.Empty<FeedbackGroup>();
//            }
//        }


//        public override async Task<IEnumerable<FeedbackGroup>> GetAll()
//        {
//            try
//            {
//                return await _dbSet.Where(x => x.Status == 1)
//                    .AsNoTracking()
//                    .AsSplitQuery()
//                    .OrderBy(x => x.AddedDate)
//                    .ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "{Repo} GetAll function error", typeof(FeedbackGroupRepository));
//                throw;

//            }
//        }

//        public override async Task<bool> Delete(Guid id)
//        {
//            try
//            {
//                //get by id
//                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

//                if (result == null)
//                    return false;

//                result.Status = 0; 
//                result.UpdatedDate = DateTime.UtcNow;

//                return true;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "{Repo} Delete function error", typeof(FeedbackGroupRepository));
//                throw;

//            }
//        }


//        public override async Task<bool> Update(FeedbackGroup feedbackGroup)
//        {
//            try
//            {
//                var result = await _dbSet
//                    .Include(ag => ag.FeedbackGroupStudents)
//                    .FirstOrDefaultAsync(x => x.Id == feedbackGroup.Id);

//                if (result == null)
//                    return false;

//                result.UpdatedDate = DateTime.UtcNow;
//                result.GroupName = feedbackGroup.GroupName;

//                var newStudentIds = feedbackGroup.StudentIds ?? new List<Guid>();
//                var existingStudentIds = result.FeedbackGroupStudents.Select(s => s.StudentId).ToList();

//                // Students to be added
//                var studentsToAdd = newStudentIds.Except(existingStudentIds).ToList();
//                foreach (var studentId in studentsToAdd)
//                {
//                    result.FeedbackGroupStudents.Add(new FeedbackGroupStudent { StudentId = studentId });
//                }

//                // Students to be removed
//                var studentsToRemove = existingStudentIds.Except(newStudentIds).ToList();
//                foreach (var studentId in studentsToRemove)
//                {
//                    var studentToRemove = result.FeedbackGroupStudents.FirstOrDefault(s => s.StudentId == studentId);
//                    if (studentToRemove != null)
//                        result.FeedbackGroupStudents.Remove(studentToRemove);
//                }

//                await _context.SaveChangesAsync();

//                return true;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "{Repo} Update function error", typeof(FeedbackGroupRepository));
//                throw;
//            }
//        }

//    }
//}
