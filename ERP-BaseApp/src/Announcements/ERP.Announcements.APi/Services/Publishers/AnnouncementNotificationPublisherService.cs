using ERP.Announcements.Api.Services.Publishers.Interfaces;
using ERP.Announcements.Core.Contracts;
using MassTransit;

namespace ERP.Announcements.Api.Services.Publishers
{

    public class AnnouncementNotificationPublisherService : IAnnouncementNotificationPublisherService
    {
        private readonly ILogger<AnnouncementNotificationPublisherService> logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public AnnouncementNotificationPublisherService(ILogger<AnnouncementNotificationPublisherService> logger, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotification(AnnouncementCreatedNotificationRecord announcement)
        {
            logger.LogInformation($"Notification {announcement.AnnouncementId}");
            await _publishEndpoint.Publish(announcement);
        }

    }
}
