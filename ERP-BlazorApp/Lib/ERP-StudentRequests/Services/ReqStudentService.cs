using ERP_StudentRequests.Core.DTOs.Request;
using ERP_StudentRequests.Core.DTOs.Response;
using ERP_StudentRequests.Services.Interfaces;

namespace ERP_StudentRequests.Services
{
    public class ReqStudentService : IStudentService
    {
        public Task<GetStudentResponse?> AddStudent(CreateStudentRequest student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GetStudentResponse?> GetStudentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetStudentResponse>> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDriver(UpdateStudentRequest student)
        {
            throw new NotImplementedException();
        }
    }
}
