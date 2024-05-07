

namespace ERP.Announcements.Core.Entity
{
    public class AnnouncementGroupStudent : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid AnnouncementGroupId { get; set; }
        public AnnouncementGroup AnnouncementGroup { get; set; }
    }
}
