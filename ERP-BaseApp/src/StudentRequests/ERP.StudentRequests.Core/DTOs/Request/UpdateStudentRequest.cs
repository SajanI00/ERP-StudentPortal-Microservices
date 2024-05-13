using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.StudentRequests.Core.DTOs.Request
{
    public class UpdateStudentRequest
    {
        public Guid StudentId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string RegNo { get; set; } = string.Empty;
        //public string Batch { get; set; } = string.Empty;
        //public string Degree { get; set; } = string.Empty;
        //public string Semester { get; set; } = string.Empty;
    }
}
