

using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Core.Interfaces
{
    public interface IReplyRepository : IGenericRepository<Reply>
    {
        Task<IEnumerable<Reply>> GetStudentReplyAsync(Guid studentId);

        Task<IEnumerable<Reply>> GetLecturerReplyAsync(Guid lecturerId);

        Task<IEnumerable<Reply>> GetRequestReplyAsync(Guid requestId);
    }
}
