using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhuKien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        PhuKienDTContext db = new PhuKienDTContext();
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category ca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(ca);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(ca);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ca = db.Categories.SingleOrDefault(x => x.MaDanhMuc == id);
            return View(ca);
        }
        [HttpPost]
        public IActionResult Edit(Category ca)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(ca).State = EntityState.Modified;
                    db.SaveChanges();
                    return Redirect("/Admin/Category/Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(ca);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var danhMuc = db.Categories.FirstOrDefault(x => x.MaDanhMuc == id);
                db.Categories.Remove(danhMuc);
                db.SaveChanges();
                
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View("/Admin/Category/Index");

        }
    }
}
