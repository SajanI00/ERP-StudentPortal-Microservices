


namespace ERP.StudentFeedback.Core.Entity
{
    public class Lecturer : BaseEntity
    {
        public Lecturer()
        {
            Feedbacks = new HashSet<Feedback>();

        //    FeedbackGroups = new HashSet<FeedbackGroup>();

      //      ModulesTeaching = new HashSet<Module>();
            LecturersModules = new HashSet<LecturersModules>();

        //    SemestersTeaching = new HashSet<Semester>();
            LecturersSemesters = new HashSet<LecturersSemesters>();
        }


        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public virtual ICollection<Feedback> Feedbacks { get; set; }

   //     public virtual ICollection<FeedbackGroup> FeedbackGroups { get; set; }

    //    public virtual ICollection<Module> ModulesTeaching { get; set; }
        public virtual ICollection<LecturersModules> LecturersModules { get; set; }

    //    public virtual ICollection<Semester> SemestersTeaching { get; set; }
        public virtual ICollection<LecturersSemesters> LecturersSemesters { get; set; }
    }
}
