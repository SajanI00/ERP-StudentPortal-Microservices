

namespace ERP_StudentRequests.Core.DTOs.Request
{
    public class CreateReplyRequest
    {
        public Guid RequestId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
