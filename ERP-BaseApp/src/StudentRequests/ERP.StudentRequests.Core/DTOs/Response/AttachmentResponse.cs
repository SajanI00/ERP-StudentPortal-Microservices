﻿

namespace ERP.StudentRequests.Core.DTOs.Response
{
    public class AttachmentResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
    }
}
