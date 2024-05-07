

namespace ERP.Announcements.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }

        ISenderRepository Senders { get; }

        IAnnouncementGroupRepository AnnouncementGroups { get; }

        IAnnouncementRepository Announcements { get; }

        Task<bool> CompleteAsync();

    }
}
