

namespace ERP.StudentFeedback.Core.DTOs.Response
{
    public class GetStudentResponse
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;
    }
}
