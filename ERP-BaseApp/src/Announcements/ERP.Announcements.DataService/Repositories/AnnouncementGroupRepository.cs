using ERP.Announcements.Core.Entity;
using ERP.Announcements.Core.Interfaces;
using ERP.Announcements.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ERP.Announcements.DataService.Repositories
{
    public class AnnouncementGroupRepository : GenericRepository<AnnouncementGroup>, IAnnouncementGroupRepository
    {
        public AnnouncementGroupRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<AnnouncementGroup>> GetStudentAnnouncementGroupAsync(Guid studentId)
        {
            try
            {
                return await _dbSet
                    .Include(ag => ag.AnnouncementGroupStudents)
                    .Where(ag => ag.AnnouncementGroupStudents.Any(s => s.StudentId == studentId))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetStudentAnnouncementGroupsAsync function error", typeof(AnnouncementGroupRepository));
                throw;
            }
        }

        public async Task<IEnumerable<AnnouncementGroup>> GetSenderAnnouncementGroupAsync(Guid senderId)
        {
            try
            {
                return await _dbSet
                   .Where(s => s.SenderId == senderId)
                   .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetSenderAnnouncementGroupAsync function error", typeof(AnnouncementGroupRepository));
                return Enumerable.Empty<AnnouncementGroup>();
            }



        }

        public override async Task<IEnumerable<AnnouncementGroup>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(AnnouncementGroupRepository));
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

                result.Status = 0; //the way the result is deleted is by making it as 0
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AnnouncementGroupRepository));
                throw;

            }
        }


        public override async Task<bool> Update(AnnouncementGroup announcementGroup)
        {
            try
            {
                var result = await _dbSet
                    .Include(ag => ag.AnnouncementGroupStudents)
                    .FirstOrDefaultAsync(x => x.Id == announcementGroup.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.GroupName = announcementGroup.GroupName;

                var newStudentIds = announcementGroup.StudentIds ?? new List<Guid>();
                var existingStudentIds = result.AnnouncementGroupStudents.Select(s => s.StudentId).ToList();

                // Students to be added
                var studentsToAdd = newStudentIds.Except(existingStudentIds).ToList();
                foreach (var studentId in studentsToAdd)
                {
                    result.AnnouncementGroupStudents.Add(new AnnouncementGroupStudent { StudentId = studentId });
                }

                // Students to be removed
                var studentsToRemove = existingStudentIds.Except(newStudentIds).ToList();
                foreach (var studentId in studentsToRemove)
                {
                    var studentToRemove = result.AnnouncementGroupStudents.FirstOrDefault(s => s.StudentId == studentId);
                    if (studentToRemove != null)
                        result.AnnouncementGroupStudents.Remove(studentToRemove);
                }


                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(AnnouncementGroupRepository));
                throw;
            }
        }
    }
}
