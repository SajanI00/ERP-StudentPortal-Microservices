
namespace ERP.Announcements.Core.Entity
{
    public class Sender : BaseEntity
    {
        public Sender()
        {
            Announcements = new HashSet<Announcement>();
            AnnouncementGroups = new HashSet<AnnouncementGroup>();
        }


        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<AnnouncementGroup> AnnouncementGroups { get; set; }
    }
}
