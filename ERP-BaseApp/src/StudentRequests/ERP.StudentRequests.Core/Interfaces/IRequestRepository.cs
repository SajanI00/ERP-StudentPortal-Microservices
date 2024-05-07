using ERP.StudentRequests.Core.Entity;


namespace ERP.StudentRequests.Core.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<IEnumerable<Request>> GetStudentRequestAsync(Guid studentId);

        Task<Request?> GetLecturerRequestAsync(Guid lecturerId);
    }
}
