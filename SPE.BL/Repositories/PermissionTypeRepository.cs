﻿using SPE.BL.Abstract.IRepositories;
using SPE.BL.Repositories.Base;
using SPE.DataModel.Context;
using SPE.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPE.BL.Repositories
{
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(SPEDbContext context)
            :base(context)
        {

        }
    }
}
