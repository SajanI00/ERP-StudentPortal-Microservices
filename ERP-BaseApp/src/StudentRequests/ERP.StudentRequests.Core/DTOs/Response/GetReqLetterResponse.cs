

namespace ERP.StudentRequests.Core.DTOs.Response
{
    public class GetReqLetterResponse
    {
        public Guid RequestId { get; set; }

        public Guid StudentId { get; set; }

        public Guid LecturerId { get; set; }

        public DateTime AddedDate { get; set; }

        public string Topic { get; set; } = string.Empty;

        public string RequestType { get; set; } = string.Empty;

        public string LecturerName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;

        public string StudentRegNo { get; set; } = string.Empty;

        public string StudentBatch { get; set; } = string.Empty;

        public string StudentDegree { get; set; } = string.Empty;

        public string Semester { get; set; } = string.Empty;
    }
}
