using ERP.Announcements.Core.Entity;


namespace ERP.Announcements.Core.Interfaces
{
    public interface IAnnouncementGroupRepository : IGenericRepository<AnnouncementGroup>
    {
        Task<IEnumerable<AnnouncementGroup>> GetStudentAnnouncementGroupAsync(Guid studentId);

        Task<IEnumerable<AnnouncementGroup>> GetSenderAnnouncementGroupAsync(Guid senderId);
    }
}
