using ERP.Announcements.Core.Entity;


namespace ERP.Announcements.Core.Interfaces
{
    public interface IAnnouncementRepository : IGenericRepository<Announcement>
    {
        Task<IEnumerable<Announcement>> GetAnnouncementGroupAnnouncementAsync(Guid announcementGroupId);

        Task<IEnumerable<Announcement>> GetSenderAnnouncementAsync(Guid senderId);

        Task<IEnumerable<Announcement>> GetStudentAnnouncementAsync(Guid studentId);
    }
}
