using Microsoft.AspNetCore.Mvc;
using PhuKien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        PhuKienDTContext db = new PhuKienDTContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult List()
        {
            return Json(db.Suppliers.ToList());
        }
        [HttpPost]
        public JsonResult Create([FromBody] Supplier sup)
        {
            db.Suppliers.Add(sup);
            db.SaveChanges();
            return Json(sup);

        }
        public JsonResult GetByID(int id)
        {
            Supplier sup = db.Suppliers.Find(id);
            return Json(sup);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Supplier sup)
        {
            db.Entry(sup).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return Json(sup);
        }
        public JsonResult Delete(int id)
        {
            Supplier sup = db.Suppliers.Find(id);
            db.Suppliers.Remove(sup);
            db.SaveChanges();
            return Json(sup);
        }
    }
}
