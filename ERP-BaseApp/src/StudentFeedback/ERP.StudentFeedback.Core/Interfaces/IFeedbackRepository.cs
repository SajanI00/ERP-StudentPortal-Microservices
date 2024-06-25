using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.Core.Interfaces
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
   //     Task<IEnumerable<Feedback>> GetFeedbackGroupFeedbackAsync(Guid feedbackGroupId);

        Task<IEnumerable<Feedback>> GetLecturerFeedbackAsync(Guid lecturerId);

       // Task<IEnumerable<Feedback>> GetStudentFeedbackAsync(Guid studentId);
    }
}
