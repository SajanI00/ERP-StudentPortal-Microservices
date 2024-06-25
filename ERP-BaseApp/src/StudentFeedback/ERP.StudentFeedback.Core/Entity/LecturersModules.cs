using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentFeedback.Core.Entity
{
    public class LecturersModules: BaseEntity
    {
        public Guid LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public Lecturer? Lecturer { get; set; }

        public Guid ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public Module? Module { get; set; }
    }
}
