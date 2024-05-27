

namespace ERP.StudentRegistration.Core.DTO.Request
{
    public class UpdateStudentRequest
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}
