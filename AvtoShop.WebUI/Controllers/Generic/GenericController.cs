using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreGenericRepository.Common;
using AvtoShop.DataLayer.Common;

namespace AvtoShop.WebUI.Controllers.Generic
{
    public class GenericController<T> : Controller, IPathAction where T : EntityExtension<int>, new()
    {
        IGenericRepository<T> repT;

        public string Path { get; set; }

        public GenericController(IGenericRepository<T> repT)
        {
            this.repT = repT;
        }
        public IActionResult Index()
        {
            ViewBag.Path = Path;
            var model = repT.GetAll();
            return View(model);
        }
        public IActionResult Edit(int id = 0)
        {
            var model = (id == 0) ? new T() : repT.Get(id);
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult Edit(T obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    repT.Add(obj);
                }
                else
                    repT.Update(obj, obj.Id);
                repT.Save();
                return Json("OK");
                //return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var obj = repT.Get(id);
            repT.Delete(obj);
            repT.Save();
            return Ok();
        }
    }
}