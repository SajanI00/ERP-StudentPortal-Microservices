

namespace ERP.Announcements.Core.Entity
{
    public class Student : BaseEntity
    {
        public Student()
        {
            AnnouncementGroups = new HashSet<AnnouncementGroup>();
            AnnouncementGroupStudents = new HashSet<AnnouncementGroupStudent>();
        }


        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;

        //public string Batch { get; set; } = string.Empty;
        //public string Degree { get; set; } = string.Empty;
        //public string Semester { get; set; } = string.Empty;


        public virtual ICollection<AnnouncementGroup> AnnouncementGroups { get; set; }

        public virtual ICollection<AnnouncementGroupStudent> AnnouncementGroupStudents { get; set; }


    }
}
