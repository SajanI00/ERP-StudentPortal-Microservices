﻿

namespace ERP_SiteHome.DTOs.Response
{
    public class GetBatchResponse
    {
        public Guid BatchId { get; set; }
        public Guid DepartmentId { get; set; }
        public string BatchName { get; set; } = string.Empty;
    }
}
