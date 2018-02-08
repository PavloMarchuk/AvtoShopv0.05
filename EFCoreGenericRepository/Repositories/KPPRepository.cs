using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreGenericRepository.Repositories
{
    public class KPPRepository : GenericRepository<KPP>
    {
        public KPPRepository(DbContext context) : base(context)
        {
        }
    }
}
