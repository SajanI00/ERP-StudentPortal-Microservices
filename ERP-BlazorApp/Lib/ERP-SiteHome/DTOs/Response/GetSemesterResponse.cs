

namespace ERP_SiteHome.DTOs.Response
{
    public class GetSemesterResponse
    {
        public Guid SemesterId { get; set; }
        public Guid BatchId { get; set; }
        public string SemesterName { get; set; } = string.Empty;
    }
}
