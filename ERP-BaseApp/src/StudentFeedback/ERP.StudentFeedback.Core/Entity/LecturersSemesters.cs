

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentFeedback.Core.Entity
{
    public class LecturersSemesters: BaseEntity
    {
        public Guid LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public Lecturer? Lecturer { get; set; }

        public Guid SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester? Semester { get; set; }
    }
}
