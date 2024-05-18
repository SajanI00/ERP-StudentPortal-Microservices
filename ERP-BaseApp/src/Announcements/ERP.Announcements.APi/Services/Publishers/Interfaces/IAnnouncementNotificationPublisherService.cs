using ERP.Announcements.Core.Contracts;

namespace ERP.Announcements.Api.Services.Publishers.Interfaces
{
    public interface IAnnouncementNotificationPublisherService
    {
        Task SendNotification(AnnouncementCreatedNotificationRecord announcement);
    }
}
