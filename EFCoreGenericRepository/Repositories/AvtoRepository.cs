﻿using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreGenericRepository.Repositories
{

    public class AvtoRepository : GenericRepository<Avto>
    {
        public AvtoRepository(DbContext context) : base(context)
        {
        }
    }
}
