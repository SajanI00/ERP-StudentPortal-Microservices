using ERP.StudentRequests.Core.Entity;


namespace ERP.StudentRequests.Core.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<IEnumerable<Request>> GetStudentRequestAsync(Guid studentId);

        Task<IEnumerable<Request>> GetLecturerRequestAsync(Guid lecturerId);
    }
}
