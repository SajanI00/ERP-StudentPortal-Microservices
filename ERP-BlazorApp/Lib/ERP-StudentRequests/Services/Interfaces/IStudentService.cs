using ERP_StudentRequests.Core.DTOs.Request;
using ERP_StudentRequests.Core.DTOs.Response;

namespace ERP_StudentRequests.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<GetStudentResponse>> GetStudents();
        Task<GetStudentResponse?> GetStudentById(Guid id);
        Task<GetStudentResponse?> AddStudent(CreateStudentRequest student);
        Task<bool> UpdateDriver(UpdateStudentRequest student);
        Task<bool> DeleteStudent(Guid id);
    }
}
