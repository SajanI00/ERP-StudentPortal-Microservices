

namespace ERP.StudentRequests.Core.Entity
{
    public class Lecturer : BaseEntity
    {
        public Lecturer()
        {
            Requests = new HashSet<Request>();
        }


        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
