

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Announcements.Core.Entity
{
    public class AnnouncementGroup : BaseEntity
    {
        public AnnouncementGroup()
        {

            Announcements = new HashSet<Announcement>();
            AnnouncementGroupStudents = new HashSet<AnnouncementGroupStudent>();
            StudentIds = new List<Guid>();
        }

        public string GroupName { get; set; } = string.Empty;

        public List<Guid> StudentIds { get; set; } = new List<Guid>();

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<AnnouncementGroupStudent> AnnouncementGroupStudents { get; set; }

        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Sender? Sender { get; set; }
    }
}
