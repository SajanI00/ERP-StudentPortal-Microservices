

using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.StudentRequests.Core.Entity
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public byte[] Data { get; set; } = Array.Empty<byte>();

        public Guid RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; } = null!;
    }
}
