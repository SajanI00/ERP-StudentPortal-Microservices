
namespace ERP.Announcements.Core.DTOs.Request
{
    public class CreateAnnouncementGroupRequest
    {
        public Guid SenderId { get; set; }

        public string GroupName { get; set; } = string.Empty;

        public required List<Guid> StudentIds { get; set; }
    }
}
