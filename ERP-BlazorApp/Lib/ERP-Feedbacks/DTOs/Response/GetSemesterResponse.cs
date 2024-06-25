

namespace ERP_Feedbacks.DTOs.Response
{
    public class GetSemesterResponse
    {
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; } = string.Empty;
    }
}
