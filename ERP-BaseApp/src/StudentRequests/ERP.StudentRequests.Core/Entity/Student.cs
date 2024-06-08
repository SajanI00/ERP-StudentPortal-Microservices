

namespace ERP.StudentRequests.Core.Entity
{
    public class Student : BaseEntity
    {
        public Student()
        {
            Requests = new HashSet<Request>();
            Replies = new HashSet<Reply>();
        }


        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;

        //public string Batch { get; set; } = string.Empty;
       // public string Degree { get; set; } = string.Empty;
        //public string Semester { get; set; } = string.Empty;

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }

    }
}
