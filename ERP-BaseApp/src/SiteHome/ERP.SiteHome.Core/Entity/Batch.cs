using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.SiteHome.Core.Entity
{
    public class Batch : BaseEntity
    {
        public Batch() 
        { 
            Semesters = new HashSet<Semester>(); 
        }
        public string BatchName { get; set; } = string.Empty;

        public virtual ICollection<Semester> Semesters { get; set; }

        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; } = null!;
    }
}
