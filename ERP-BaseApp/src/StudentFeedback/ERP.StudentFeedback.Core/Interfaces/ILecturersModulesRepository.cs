using ERP.StudentFeedback.Core.Entity;

namespace ERP.StudentFeedback.Core.Interfaces
{
    public interface ILecturersModulesRepository : IGenericRepository<LecturersModules>
    {
        Task<IEnumerable<LecturersModules>> GetOneLecturersModulesAsync(Guid lecturerId);
    }
}
