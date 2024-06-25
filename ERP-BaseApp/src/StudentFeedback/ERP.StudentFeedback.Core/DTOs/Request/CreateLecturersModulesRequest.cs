

namespace ERP.StudentFeedback.Core.DTOs.Request
{
    public class CreateLecturersModulesRequest
    {
        public Guid LecturerId { get; set; }
        public Guid ModuleId { get; set; }
    }
}
