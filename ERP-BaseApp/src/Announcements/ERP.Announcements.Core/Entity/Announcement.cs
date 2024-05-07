
using System.ComponentModel.DataAnnotations.Schema;


namespace ERP.Announcements.Core.Entity
{
    public class Announcement : BaseEntity
    {

        public string AnnouncementType { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public string AnnouncementGroupName { get; set; } = string.Empty;

        public string SenderName { get; set; } = string.Empty;


        public Guid AnnouncementGroupId { get; set; }
        [ForeignKey("AnnouncementGroupId")]
        public virtual AnnouncementGroup? AnnouncementGroup { get; set; }


        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Sender? Sender { get; set; }
    }
}
