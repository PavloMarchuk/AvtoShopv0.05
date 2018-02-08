using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreGenericRepository.Common;
using AvtoShop.DataLayer.DbLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using AvtoShop.WebUI.Models;
using Microsoft.AspNetCore.Authorization;

namespace AvtoShop.WebUI.Controllers
{
	[Authorize(Roles = "AppModerator")]
	public class ModelAvtoController : Controller
    {
        IGenericRepository<ModelAvto> repModelAvto;
        IGenericRepository<Brand> repBrand;
        public ModelAvtoController(IGenericRepository<ModelAvto> repModelAvto,
            IGenericRepository<Brand> repBrand)
        {
            this.repModelAvto = repModelAvto;
            this.repBrand = repBrand;
        }
        public IActionResult Index()
        {
            var model = repModelAvto.GetAll()
                .Select(m => new ViewModelModelAvto
                {
                    ModelAvtoId = m.ModelAvtoId,
                    BrandName = m.Brand.Name,
                    ModelName = m.ModelName
                });
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = repModelAvto.Get(id);
            ViewBag.BrandId = new SelectList(repBrand.GetAll().ToList(), 
                        "Id", "Name",
                        model.BrandId);
            return View(model);
        }
    }
}