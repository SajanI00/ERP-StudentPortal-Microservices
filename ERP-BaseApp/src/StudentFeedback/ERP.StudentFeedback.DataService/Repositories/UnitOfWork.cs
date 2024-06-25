using ERP.StudentFeedback.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ERP.StudentFeedback.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        public readonly AppDbContext _context;

        public IStudentRepository Students { get; }
        public ILecturerRepository Lecturers { get; }
        public IModuleRepository Modules { get; }
        public ISemesterRepository Semesters { get; }
        public ILecturersModulesRepository LecturersModules { get; }
        public ILecturersSemestersRepository LecturersSemesters { get; }

      //  public IFeedbackGroupRepository FeedbackGroups { get; }
        public IFeedbackRepository Feedbacks { get; }
        public IFeedbackResponsesRepository FeedbackResponses { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("Logs");

            Students = new StudentRepository(_context, logger);
            Lecturers = new LecturerRepository(_context, logger);
            Modules = new ModuleRepository(_context, logger);
            Semesters = new SemesterRepository(_context, logger);
            LecturersModules = new LecturersModulesRepository(_context, logger);
            LecturersSemesters = new LecturersSemestersRepository(_context, logger);
        //    FeedbackGroups = new FeedbackGroupRepository(_context, logger);
            Feedbacks = new FeedbackRepository(_context, logger);
            FeedbackResponses = new FeedbackResponsesRepository(_context, logger);

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
