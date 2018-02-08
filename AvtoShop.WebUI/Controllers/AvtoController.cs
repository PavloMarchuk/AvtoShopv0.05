using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreGenericRepository.Common;
using AvtoShop.DataLayer.DbLayer;
using AvtoShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace AvtoShop.WebUI.Controllers
{
	[Authorize ]
	public class AvtoController : Controller
    {
        IGenericRepository<Avto> repAvto;
        IGenericRepository<Brand> repBrand;
        IGenericRepository<ModelAvto> repModelAvto;
        IGenericRepository<DriveUnit> repDriveUnit;
        public AvtoController(IGenericRepository<Avto> repAvto,
                                IGenericRepository<Brand> repBrand,
                                IGenericRepository<ModelAvto> repModelAvto,
                                IGenericRepository<DriveUnit> repDriveUnit)
        {
            this.repAvto = repAvto;
            this.repBrand = repBrand;
            this.repModelAvto = repModelAvto;
            this.repDriveUnit = repDriveUnit;
        }

        public IActionResult Index()
        {
			IQueryable<Avto> iqList;
			if (User.IsInRole("AppModerator"))
			{
				iqList = repAvto.GetAll();
			}
			else
			{//вибірка  автомобілів тільки цього юзвєря
				string user = User.Identity.Name;
				iqList = repAvto.FindBy(f=>f.UserName == user);
			}
			
			IQueryable<ViewModelAvto> model = iqList.Select(a => new ViewModelAvto
                {
                    AvtoId = a.AvtoId,
                    BrandName = a.ModelAvto.Brand.Name,
                    ModelAvtoName = a.ModelAvto.ModelName,
                    UserName = a.UserName,
                    YearAvto = a.YearAvto,
                    Price = a.Price
                });

            return View(model);
        }
        public IActionResult Edit(int id=0)
        {
            var model = (id == 0) ? new Avto() : repAvto.Get(id);
            ViewBag.DriveUnitId = new SelectList(GetDriveUnit.Union(repDriveUnit.GetAll()), "Id", "Name", model.DriveUnitId);
            ViewBag.BrandId = (id == 0) ? 
                    new SelectList(GetBrand.Union(repBrand.GetAll()), "Id", "Name"):
                    new SelectList(GetBrand.Union(repBrand.GetAll()), "Id", "Name", model.ModelAvto.BrandId);
            ViewBag.ModelAvtoId = (model.ModelAvtoId == null)
                ? new SelectList(GetModelAvtoNull , "ModelAvtoId", "ModelName")
                : new SelectList(GetModelAvto(model.ModelAvto.BrandId), "ModelAvtoId", "ModelName", model.ModelAvtoId);


            return View(model);
        }
		[HttpPost]
		public IActionResult Edit(Avto model)
		{
			if (ModelState.IsValid)
			{

			}
			return View(model);
		}


		public IActionResult GetModelAvtoPartView(int? BrandId)
        {
            var model = GetModelAvto(BrandId);
            ViewBag.ModelAvtoId = new SelectList(GetModelAvtoNull.Union(model), "ModelAvtoId", "ModelName");
            return PartialView();

        }
        IEnumerable<ModelAvto> GetModelAvto(int? BrandId)
        {
            return repModelAvto.FindBy(p => p.BrandId == BrandId);
        }
        IEnumerable<ModelAvto> GetModelAvtoNull
        {
            get
            {
                yield return new ModelAvto { ModelAvtoId = 0, ModelName = "Выберите модель авто" };
            }
        }


		IEnumerable<DriveUnit> GetDriveUnit
        {
            get
            {
                yield return new DriveUnit { Id = 0, Name = "Выберите привод" };
            }
        }
        IEnumerable<Brand> GetBrand
        {
            get
            {
                yield return new Brand { Id = 0, Name = "Выберите марку авто" };
            }
        }
        
    }
}