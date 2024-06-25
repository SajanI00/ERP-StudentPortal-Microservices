﻿using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ERP.SiteHome.DataService.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(DepartmentRepository));
                throw;

            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                //get by id
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0; //the way the result is deleted is by making it as 0
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(DepartmentRepository));
                throw;

            }
        }
    }
}
