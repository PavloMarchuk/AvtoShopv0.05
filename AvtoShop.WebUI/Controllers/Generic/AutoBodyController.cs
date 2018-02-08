using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvtoShop.WebUI.Controllers.Generic
{
	[Authorize(Roles = "Admin")]
	public class AutoBodyController : GenericController<AutoBody>
	{
		public AutoBodyController(IGenericRepository<AutoBody> repKPP) : base(repKPP)
		{
			Path = "AutoBody";
		}
	}
	
}