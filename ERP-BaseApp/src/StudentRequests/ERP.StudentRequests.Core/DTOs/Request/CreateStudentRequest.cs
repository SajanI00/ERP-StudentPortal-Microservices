

namespace ERP.StudentRequests.Core.DTOs.Request
{
    public class CreateStudentRequest
    {
        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;
        public string Batch { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
    }
}
