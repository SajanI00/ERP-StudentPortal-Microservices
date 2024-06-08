using ERP_StudentRequests.Core.DTOs.Request;
using ERP_StudentRequests.Core.DTOs.Response;

namespace ERP_StudentRequests.Services.Interfaces
{
    public interface IRequestService
    {
        Task<List<GetReqLetterResponse>> GetRequests();
        Task<GetReqLetterResponse?> GetRequestById(Guid id);
        Task<GetReqLetterResponse?> AddRequest(CreateReqLetterRequest student);
        Task<bool> DeleteRequest(Guid id);
    }
}
