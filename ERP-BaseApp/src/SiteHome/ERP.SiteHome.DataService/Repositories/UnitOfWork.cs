using Microsoft.Extensions.Logging;
using ERP.SiteHome.Core.Interfaces;

namespace ERP.SiteHome.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        public readonly AppDbContext _context;

        public IDepartmentRepository Departments { get; }
        public ISemesterRepository Semesters { get; }
        public IBatchRepository Batches { get; }


        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("Logs");

            Departments = new DepartmentRepository(_context, logger);
            Semesters = new SemesterRepository(_context, logger);
            Batches = new BatchRepository(_context, logger);


        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
