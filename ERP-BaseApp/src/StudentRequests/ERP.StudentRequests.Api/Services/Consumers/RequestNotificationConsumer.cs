using ERP.Messaging.Core.Student;
using ERP.StudentRequests.Core.Contracts;
using MassTransit;

namespace ERP.StudentRequests.Api.Services.Consumers
{

    public class RequestNotificationConsumer : IConsumer<RequestCreatedNotificationRecord>
    {
        private readonly ILogger<RequestNotificationConsumer> _logger;

        public RequestNotificationConsumer(ILogger<RequestNotificationConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<RequestCreatedNotificationRecord> context)
        {
            _logger.LogInformation($"Student Requests Log : Recieved {context.Message.RequestId} from Student {context.Message.StudentName} to Lecturer {context.Message.LecturerName}");
            return Task.CompletedTask;
        }
    }
}
