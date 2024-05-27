

namespace ERP.StudentRequests.Core.DTOs.Response
{
    public class GetReqLetterResponse
    {
        public Guid StudentId { get; set; }

        public Guid LecturerId { get; set; }

        public Guid RequestId { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        public string Topic { get; set; } = string.Empty;

        public string RequestType { get; set; } = string.Empty;

        public string LecturerName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;

        public string StudentRegNo { get; set; } = string.Empty;

        public string StudentBatch { get; set; } = string.Empty;

        public string StudentDegree { get; set; } = string.Empty;
    }
}
