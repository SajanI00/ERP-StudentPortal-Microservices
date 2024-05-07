
namespace ERP.Announcements.Core.DTOs.Request
{
    public class CreateAnnouncementRequest
    {
        public Guid SenderId { get; set; }

        public Guid AnnouncementGroupId { get; set; }

        public string AnnouncementType { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public string AnnouncementGroupName { get; set; } = string.Empty;

        public string SenderName { get; set; } = string.Empty;
    }
}