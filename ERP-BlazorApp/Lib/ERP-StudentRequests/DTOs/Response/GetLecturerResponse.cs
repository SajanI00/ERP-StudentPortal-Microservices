

namespace ERP_StudentRequests.Core.DTOs.Response
{
    public class GetLecturerResponse
    {
        public Guid LecturerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
