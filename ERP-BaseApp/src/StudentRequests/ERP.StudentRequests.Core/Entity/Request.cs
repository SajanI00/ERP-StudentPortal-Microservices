
using System.ComponentModel.DataAnnotations.Schema;


namespace ERP.StudentRequests.Core.Entity
{
    public class Request : BaseEntity
    {
        public string Topic { get; set; } = string.Empty;

        public string RequestType { get; set; } = string.Empty;

        public string LecturerName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;

        public string StudentRegNo { get; set; } = string.Empty;

        public string StudentBatch { get; set; } = string.Empty;

        public string StudentDegree { get; set; } = string.Empty;


        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;


        public Guid LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public virtual Lecturer Lecturer { get; set; } = null!;
    }
}
