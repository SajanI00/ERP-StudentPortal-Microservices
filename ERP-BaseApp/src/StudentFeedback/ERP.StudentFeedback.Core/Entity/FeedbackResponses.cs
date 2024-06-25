

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentFeedback.Core.Entity
{
    public class FeedbackResponses : BaseEntity
    {
        public FeedbackResponses() 
        { 
         //   Feedbacks = new HashSet<Feedback>(); 
        }

        public string LecturerName { get; set; } = string.Empty;
        public string ModuleName { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;

        public Guid LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public Lecturer? Lecturer { get; set; }

        public Guid ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public Module? Module { get; set; }

        public Guid SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester? Semester { get; set; }

    //    public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
