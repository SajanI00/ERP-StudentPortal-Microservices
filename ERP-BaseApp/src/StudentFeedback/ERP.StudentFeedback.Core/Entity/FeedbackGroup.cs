
//using System.ComponentModel.DataAnnotations.Schema;


//namespace ERP.StudentFeedback.Core.Entity
//{
//    public class FeedbackGroup : BaseEntity
//    {
//        public FeedbackGroup()
//        {

//            Feedbacks = new HashSet<Feedback>();
//            FeedbackGroupStudents = new HashSet<FeedbackGroupStudent>();
//            StudentIds = new List<Guid>();
//        }

//        public string GroupName { get; set; } = string.Empty;

//        public List<Guid> StudentIds { get; set; } = new List<Guid>();

//        public virtual ICollection<Feedback> Feedbacks { get; set; }
//        public virtual ICollection<FeedbackGroupStudent> FeedbackGroupStudents { get; set; }

//        public Guid LecturerId { get; set; }
//        [ForeignKey("LecturerId")]
//        public virtual Lecturer? Lecturer { get; set; }
//    }
//}
