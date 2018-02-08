using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AvtoShop.DataLayer.DbLayer;
using EFCoreGenericRepository.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvtoShop.WebUI.Controllers.Generic
{
	[Authorize(Roles = "Admin")]
	public class DriveUnitController : GenericController<DriveUnit>
	{
		public DriveUnitController(IGenericRepository<DriveUnit> repKPP) : base(repKPP)
		{
			Path = "DriveUnit";
		}
	}
	
}