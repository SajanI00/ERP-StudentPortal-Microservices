

namespace ERP.StudentRequests.Core.DTOs.Response
{
    public class GetReplyResponse
    {
        public Guid ReplyId { get; set; }
        public Guid RequestId { get; set; }
        public Guid LecturerId { get; set; }
        public Guid StudentId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; } 
    }
}
