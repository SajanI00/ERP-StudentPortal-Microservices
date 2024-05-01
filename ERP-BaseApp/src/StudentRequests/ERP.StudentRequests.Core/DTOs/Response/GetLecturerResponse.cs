using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StudentRequests.Core.DTOs.Response
{
    public class GetLecturerResponse
    {
        public Guid LecturerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
