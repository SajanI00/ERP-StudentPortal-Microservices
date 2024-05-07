using ERP.Announcements.Core.Interfaces;
using ERP.Announcements.DataService.Data;
using Microsoft.Extensions.Logging;


namespace ERP.Announcements.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        public readonly AppDbContext _context;

        public IStudentRepository Students { get; }

        public ISenderRepository Senders { get; }

        public IAnnouncementGroupRepository AnnouncementGroups { get; }

        public IAnnouncementRepository Announcements { get; }


        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("Logs");

            Students = new StudentRepository(_context, logger);
            Senders = new SenderRepository(_context, logger);
            AnnouncementGroups = new AnnouncementGroupRepository(_context, logger);
            Announcements = new AnnouncementRepository(_context, logger);

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

