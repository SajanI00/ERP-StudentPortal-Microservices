using ERP.StudentRequests.Api.Services.Publishers.Interfaces;
using ERP.StudentRequests.Core.Contracts;
using MassTransit;

namespace ERP.StudentRequests.Api.Services.Publishers
{
    public class RequestNotificationPublisherService : IRequestNotificationPublisherService
    {
        private readonly ILogger<RequestNotificationPublisherService> logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public RequestNotificationPublisherService(ILogger<RequestNotificationPublisherService> logger, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this._publishEndpoint = publishEndpoint;
        }

        public async Task SendNotification(RequestCreatedNotificationRecord request)
        {
            logger.LogInformation($"Notification {request.RequestId}");
            await _publishEndpoint.Publish(request);
        }

    }
}
