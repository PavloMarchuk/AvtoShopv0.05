using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreGenericRepository.Repositories
{
    //class BrandRepository
    //{
    //}
    public class BrandRepository : GenericRepository<Brand>
    {
        public BrandRepository(DbContext context) : base(context)
        {
        }
    }
}
