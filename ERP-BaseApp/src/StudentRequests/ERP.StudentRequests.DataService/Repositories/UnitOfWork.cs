using Microsoft.Extensions.Logging;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.DataService.Data;

namespace ERP.StudentRequests.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        public readonly AppDbContext _context;

        public IStudentRepository Students { get; }

        public ILecturerRepository Lecturers { get; }

        public IRequestRepository Requests { get; }

        public IReplyRepository Replies { get; }

        public IAttachmentRepository Attachments { get; }


        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("Logs");

            Students = new StudentRepository(_context, logger);
            Lecturers = new LecturerRepository(_context, logger);
            Requests = new RequestRepository(_context, logger);
            Replies = new ReplyRepository(_context, logger);
            Attachments = new AttachmentRepository(_context, logger);

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
