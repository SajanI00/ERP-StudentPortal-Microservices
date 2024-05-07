

namespace ERP.StudentFeedback.Core.Entity
{
    public class Student : BaseEntity
    {
        public Student()
        {
            FeedbackGroups = new HashSet<FeedbackGroup>();
            FeedbackGroupStudents = new HashSet<FeedbackGroupStudent>();
        }


        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;
        public string Batch { get; set; } = string.Empty;

        public string Degree { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;


        public virtual ICollection<FeedbackGroup> FeedbackGroups { get; set; }

        public virtual ICollection<FeedbackGroupStudent> FeedbackGroupStudents { get; set; }


    }
}
