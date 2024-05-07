

namespace ERP.StudentFeedback.Core.Entity
{
    public class Lecturer : BaseEntity
    {
        public Lecturer()
        {
            Feedbacks = new HashSet<Feedback>();
            FeedbackGroups = new HashSet<FeedbackGroup>();
        }


        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<FeedbackGroup> FeedbackGroups { get; set; }
    }
}
