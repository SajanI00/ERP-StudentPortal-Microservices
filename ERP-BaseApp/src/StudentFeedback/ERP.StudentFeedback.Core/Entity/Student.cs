

namespace ERP.StudentFeedback.Core.Entity
{
    public class Student : BaseEntity
    {
        public Student()
        {
            //FeedbackGroups = new HashSet<FeedbackGroup>();
            //FeedbackGroupStudents = new HashSet<FeedbackGroupStudent>();

          //  Feedbacks = new HashSet<Feedback>();
        }


        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;


      //  public virtual ICollection<Feedback> Feedbacks { get; set; }

        //public virtual ICollection<FeedbackGroup> FeedbackGroups { get; set; }
        //public virtual ICollection<FeedbackGroupStudent> FeedbackGroupStudents { get; set; }


    }
}
