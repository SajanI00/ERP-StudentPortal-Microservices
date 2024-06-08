

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentRequests.Core.Entity
{
    public class Reply : BaseEntity
    {

        public string Message { get; set; } = string.Empty;

        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;


        public Guid LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public virtual Lecturer Lecturer { get; set; } = null!;

        public Guid RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; } = null!;
    }
}
