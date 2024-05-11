using ERP.StudentRequests.Core.Contracts;

namespace ERP.StudentRequests.Api.Services.Publishers.Interfaces
{
    public interface IRequestNotificationPublisherService
    {
        Task SendNotification(RequestCreatedNotificationRecord request);
    }
}
