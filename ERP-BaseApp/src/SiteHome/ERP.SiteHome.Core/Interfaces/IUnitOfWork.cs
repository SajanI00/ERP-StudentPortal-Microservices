

namespace ERP.SiteHome.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        ISemesterRepository Semesters { get; }
        IBatchRepository Batches { get; }

        Task<bool> CompleteAsync();

    }
}
