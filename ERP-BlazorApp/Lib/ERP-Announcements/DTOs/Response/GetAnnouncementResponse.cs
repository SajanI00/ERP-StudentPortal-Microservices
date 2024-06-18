

namespace ERP_Announcements.DTOs.Response
{
    public class GetAnnouncementResponse
    {
        public string AnnouncementType { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string AnnouncementGroupName { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; }
    }
}
