using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhuKien.Model.Entities;
using PhuKienDT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDT.Controllers
{
    public class HomeController : Controller
    {
        PhuKienDTContext db = new PhuKienDTContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listNew = db.Products.OrderByDescending(x => x.MaSanPham).Take(12).ToList();
            var listBest = db.Products.OrderByDescending(x => x.Gia).Take(12).ToList();
            var tuple = new Tuple<List<Product>, List<Product>>(listNew, listBest);
            return View(tuple);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Login(string usename, string password)
        {
            Customer cus = db.Customers.SingleOrDefault(x => x.UserName == usename && x.PassWord == password);
            if (cus != null)
            {
                HttpContext.Session.SetInt32("makhachhang", cus.MaKhachHang);
                HttpContext.Session.SetString("usename", cus.UserName);
                HttpContext.Session.SetString("tenkhachhang", cus.TenKhachHang);
                HttpContext.Session.Set<Customer>("avatar", cus);
                return Redirect("/Cart/Order");
            }
            ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View(cus);
        }
    }
}
