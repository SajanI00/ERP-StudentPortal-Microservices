

namespace ERP_StudentRequests.DTOs.Request
{
    public class CreateReplyRequest
    {
        public Guid RequestId { get; set; }
        public Guid LecturerId { get; set; }
        public Guid StudentId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
