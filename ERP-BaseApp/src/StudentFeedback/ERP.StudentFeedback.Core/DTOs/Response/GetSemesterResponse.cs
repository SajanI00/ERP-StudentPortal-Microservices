

namespace ERP.StudentFeedback.Core.DTOs.Response
{
    public class GetSemesterResponse
    {
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; } = string.Empty;
    }
}
