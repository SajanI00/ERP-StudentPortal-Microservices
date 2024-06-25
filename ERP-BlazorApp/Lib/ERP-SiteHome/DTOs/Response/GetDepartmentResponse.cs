

namespace ERP_SiteHome.DTOs.Response
{
    public class GetDepartmentResponse
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
