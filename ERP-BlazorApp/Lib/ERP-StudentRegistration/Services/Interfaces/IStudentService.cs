using ERP.StudentRegistration.Core.DTO.Request;
using ERP_StudentRegistration.DTOs.Response;

namespace ERP_StudentRegistration.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetStudents();
        Task<StudentResponse?> GetStudentById(Guid id);
        Task<StudentResponse?> AddStudent(CreateStudentRequest student);
        Task<bool> UpdateDriver(UpdateStudentRequest student);
        Task<bool> DeleteStudent(Guid id);
    }
}
