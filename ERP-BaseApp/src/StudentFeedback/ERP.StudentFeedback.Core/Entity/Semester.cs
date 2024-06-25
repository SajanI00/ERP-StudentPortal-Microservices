

namespace ERP.StudentFeedback.Core.Entity
{
    public class Semester : BaseEntity 
    {
        public Semester() 
        { 
            LecturersSemesters = new HashSet<LecturersSemesters>();
            //LecturerIds = new List<Guid>();
        }


        public string SemesterName { get; set; } = string.Empty;


        //public List<Guid> LecturerIds { get; set; } = new List<Guid>();
        public virtual ICollection<LecturersSemesters> LecturersSemesters { get; set; }


    }
}
