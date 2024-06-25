

namespace ERP.SiteHome.Core.Entity
{
    public class Department : BaseEntity
    {
        public Department() 
        { 
            Batches = new HashSet<Batch>(); 
           // Semesters = new HashSet<Semester>();
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;


        public virtual ICollection<Batch> Batches { get; set; }

        //public virtual ICollection<Semester> Semesters { get; set; }
    }
}
