using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AvtoShop.DataLayer.DbLayer;
using AvtoShop.WebUI.Controllers.Generic;
using EFCoreGenericRepository.Common;
using Microsoft.AspNetCore.Authorization;

namespace AvtoShop.WebUI.Controllers
{
	[Authorize(Roles = "AppModerator")]
    public class KppController : GenericController<KPP>
    {
        public KppController(IGenericRepository<KPP> repKPP): base(repKPP)
        {
            Path = "Kpp";
        }
    }
}

//
// 
