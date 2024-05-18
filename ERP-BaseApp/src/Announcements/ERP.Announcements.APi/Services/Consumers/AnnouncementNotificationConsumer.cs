using ERP.Announcements.Core.Contracts;
using MassTransit;

namespace ERP.Announcements.Api.Services.Consumers
{ 

    public class AnnouncementNotificationConsumer : IConsumer<AnnouncementCreatedNotificationRecord>
    {
        private readonly ILogger<AnnouncementNotificationConsumer> _logger;

        public AnnouncementNotificationConsumer(ILogger<AnnouncementNotificationConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<AnnouncementCreatedNotificationRecord> context)
        {
            _logger.LogInformation($"Student Announcements Log : Recieved {context.Message.AnnouncementId} from Student {context.Message.StudentGroupName} to Lecturer {context.Message.SenderName}");
            return Task.CompletedTask;
        }
    }
}
