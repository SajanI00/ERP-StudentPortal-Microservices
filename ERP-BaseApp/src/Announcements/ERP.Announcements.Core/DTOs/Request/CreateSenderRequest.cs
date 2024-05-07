

namespace ERP.Announcements.Core.DTOs.Request
{
    public class CreateSenderRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
