using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreGenericRepository.Common;
using AvtoShop.DataLayer.DbLayer;
using AvtoShop.WebUI.Controllers.Generic;
using Microsoft.AspNetCore.Authorization;

namespace AvtoShop.WebUI.Controllers
{
	[Authorize(Roles = "AppModerator")]
	public class FuelController : GenericController<Fuel>
    {
        public FuelController(IGenericRepository<Fuel> repFuel): base(repFuel)
        {
            Path = "Fuel";
        }
    }
    //public class FuelController : Controller
    //{
    //    IGenericRepository<Fuel> repFuel;
    //    public FuelController(IGenericRepository<Fuel> repFuel)
    //    {
    //        this.repFuel = repFuel;
    //    }
    //    public IActionResult Index()
    //    {
    //        var model = repFuel.GetAll();
    //        return View(model);
    //    }
    //    public IActionResult Edit(int id=0)
    //    {
    //        var model = (id==0) ?new Fuel() : repFuel.Get(id);
    //        return PartialView(model);
    //    }
    //    [HttpPost]
    //    public IActionResult Edit(Fuel obj)
    //    {
    //        if(ModelState.IsValid)
    //        {
    //            if (obj.Id == 0)
    //                repFuel.Add(obj);
    //            else repFuel.Update(obj, obj.Id);

    //            repFuel.Save();
    //            return  Json("OK");
    //        }
    //        return View(obj);
    //    }
    //    [HttpPost]
    //    public IActionResult Delete(int id)
    //    {
    //        var obj = repFuel.Get(id);
    //        repFuel.Delete(obj);
    //        repFuel.Save();
    //        return RedirectToAction("Index");
    //    }
    //}
}