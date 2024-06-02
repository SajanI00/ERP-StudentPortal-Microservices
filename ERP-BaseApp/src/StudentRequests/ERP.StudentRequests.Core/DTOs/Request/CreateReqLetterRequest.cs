

namespace ERP.StudentRequests.Core.DTOs.Request
{
    public class CreateReqLetterRequest
    {
        public Guid StudentId { get; set; }

        public Guid LecturerId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string StudentRegNo { get; set; } = string.Empty;

        public string StudentBatch { get; set; } = string.Empty;

        public string Semester { get; set; } = string.Empty;

        public string StudentDegree { get; set; } = string.Empty;

        public string LecturerName { get; set; } = string.Empty;

        public string RequestType { get; set; } = string.Empty;

        public string Topic { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
