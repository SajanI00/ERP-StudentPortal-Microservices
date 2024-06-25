

namespace ERP.StudentFeedback.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        ILecturerRepository Lecturers { get; }
        IModuleRepository Modules { get; }
        ISemesterRepository Semesters { get; }
        ILecturersModulesRepository LecturersModules { get; }
        ILecturersSemestersRepository LecturersSemesters { get; }
      //  IFeedbackGroupRepository FeedbackGroups { get; }
        IFeedbackRepository Feedbacks { get; }

        IFeedbackResponsesRepository FeedbackResponses { get; }


        Task<bool> CompleteAsync();

    }
}
