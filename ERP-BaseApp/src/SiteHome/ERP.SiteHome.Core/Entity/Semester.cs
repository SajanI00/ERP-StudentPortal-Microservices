
using System.ComponentModel.DataAnnotations.Schema;


namespace ERP.SiteHome.Core.Entity
{
    public class Semester: BaseEntity
    {

        public string SemesterName { get; set; } = string.Empty;

        public Guid BatchId { get; set; }
        [ForeignKey("BatchId")]
        public virtual Batch Batch { get; set; } = null!;
    }
}
