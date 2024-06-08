

namespace ERP.StudentRequests.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }

        ILecturerRepository Lecturers { get; }

        IRequestRepository Requests { get; }

        IReplyRepository Replies { get; }

        Task<bool> CompleteAsync();

    }
}
