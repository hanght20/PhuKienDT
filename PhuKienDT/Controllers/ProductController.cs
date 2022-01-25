using Microsoft.AspNetCore.Mvc;
using PhuKien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDT.Controllers
{
    public class ProductController : Controller
    {
        PhuKienDTContext db = new PhuKienDTContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            Product pd= db.Products.Find(id);
            return View(pd);
        }
    }
}
