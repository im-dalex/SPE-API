using Microsoft.EntityFrameworkCore;
using SPE.BL.Abstract.IRepositories;
using SPE.BL.Repositories.Base;
using SPE.DataModel.Context;
using SPE.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SPE.BL.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(SPEDbContext context)
            :base(context)
        {

        }

        public override async Task<Permission> GetById(int id)
        {
            return await _set.Include(x => x.PermissionType).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<Permission>> GetAll()
        {
            return await _set.Include(x => x.PermissionType).ToListAsync();
        }
    }
}
