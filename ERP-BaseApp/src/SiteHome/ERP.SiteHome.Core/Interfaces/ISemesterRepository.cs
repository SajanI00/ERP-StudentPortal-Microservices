using ERP.SiteHome.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.SiteHome.Core.Interfaces
{
    public interface ISemesterRepository : IGenericRepository<Semester>
    {
        Task<IEnumerable<Semester>> GetBatchSemesterAsync(Guid batchId);
    }
}
