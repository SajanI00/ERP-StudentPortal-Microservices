using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.Core.Interfaces
{
    public interface ILecturersSemestersRepository : IGenericRepository<LecturersSemesters>
    {
        Task<IEnumerable<LecturersSemesters>> GetOneLecturersSemestersAsync(Guid lecturerId);
    }
}
