

namespace ERP.StudentRequests.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }

        ILecturerRepository Lecturers { get; }

        IRequestRepository Requests { get; }

        IReplyRepository Replies { get; }

        IAttachmentRepository Attachments { get; }

        Task<bool> CompleteAsync();

    }
}
