using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreGenericRepository.Repositories
{
    public class DriveUnitRepository : GenericRepository<DriveUnit>
    {
        public DriveUnitRepository(DbContext context) : base(context)
        {
        }
    }
}
