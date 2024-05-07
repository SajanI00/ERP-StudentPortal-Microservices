
namespace ERP.Announcements.Core.DTOs.Response
{
    public class GetAnnouncementGroupResponse
    {
        public Guid AnnouncementGroupId { get; set; }

        public Guid SenderId { get; set; }

        public string GroupName { get; set; } = string.Empty;

        public List<Guid> StudentIds { get; set; }


    }
}
