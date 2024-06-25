

namespace ERP.SiteHome.Core.DTOs.Request
{
    public class CreateSemesterRequest
    {
        public Guid BatchId { get; set; }
        public string SemesterName { get; set; } = string.Empty;
    }
}
