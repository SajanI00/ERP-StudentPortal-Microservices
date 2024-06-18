using Microsoft.Extensions.Logging;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.DataService.Data;

namespace ERP.StudentRequests.DataService.Repositories
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(AppDbContext context, ILogger logger) : base(context, logger)
        { }

        public override async Task<bool> Delete(Guid id)
        {
            var attachment = await _dbSet.FindAsync(id);
            if (attachment == null) return false;
            _dbSet.Remove(attachment);
            return true;
        }

        public override async Task<bool> Update(Attachment entity)
        {
            var existingAttachment = await _dbSet.FindAsync(entity.Id);
            if (existingAttachment == null) return false;

            _context.Entry(existingAttachment).CurrentValues.SetValues(entity);
            return true;
        }

    }
}
