

namespace ERP.SiteHome.Core.DTOs.Request
{
    public class CreateBatchRequest
    {
        public Guid DepartmentId { get; set; }
        public string BatchName { get; set; } = string.Empty;
    }
}
