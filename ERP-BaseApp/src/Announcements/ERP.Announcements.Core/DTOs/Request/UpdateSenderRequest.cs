namespace ERP.Announcements.Core.DTOs.Request
{
    public class UpdateSenderRequest
    {
        public Guid SenderId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}