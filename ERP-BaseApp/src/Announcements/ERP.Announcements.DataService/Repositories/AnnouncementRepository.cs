using ERP.Announcements.Core.Entity;
using ERP.Announcements.Core.Interfaces;
using ERP.Announcements.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ERP.Announcements.DataService.Repositories
{
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        //show the announcement list
        public async Task<IEnumerable<Announcement>> GetStudentAnnouncementAsync(Guid studentId)
        {
            try
            {
                return await _dbSet
                    .Include(a => a.AnnouncementGroup)
                    .Where(a => a.AnnouncementGroup != null && a.AnnouncementGroup.StudentIds.Contains(studentId))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetStudentAnnouncementAsync function error", typeof(AnnouncementRepository));
                return Enumerable.Empty<Announcement>();
            }


        }

        public async Task<IEnumerable<Announcement>> GetSenderAnnouncementAsync(Guid senderId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.SenderId == senderId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetSenderAnnouncementAsync function error", typeof(AnnouncementRepository));
                return Enumerable.Empty<Announcement>();
            }

        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementGroupAnnouncementAsync(Guid announcementGroupId)
        {
            try
            {
                return await _dbSet
                   .Where(ag => ag.AnnouncementGroupId == announcementGroupId)
                   .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAnnouncementGroupAnnouncementAsync function error", typeof(AnnouncementRepository));
                return Enumerable.Empty<Announcement>();
            }

        }

        public override async Task<IEnumerable<Announcement>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(AnnouncementRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AnnouncementRepository));
                throw;

            }
        }

        public override async Task<bool> Update(Announcement announcement)
        {
            try
            {
                //get by id
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == announcement.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.AnnouncementType = announcement.AnnouncementType;
                result.Text = announcement.Text;
                result.AnnouncementGroupName = announcement.AnnouncementGroupName;
                result.SenderName = announcement.SenderName;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(AnnouncementRepository));
                throw;

            }
        }
    }
}
