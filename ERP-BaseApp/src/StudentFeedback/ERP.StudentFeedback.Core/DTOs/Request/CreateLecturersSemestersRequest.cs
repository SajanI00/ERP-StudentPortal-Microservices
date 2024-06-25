

namespace ERP.StudentFeedback.Core.DTOs.Request
{
    public class CreateLecturersSemestersRequest
    {
        public Guid LecturerId { get; set; }
        public Guid SemesterId { get; set; }
    }
}
