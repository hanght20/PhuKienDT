using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhuKien.Model.Entities;
using PhuKienDT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        PhuKienDTContext db = new PhuKienDTContext();
        ProcessingLogic logic = new ProcessingLogic();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User user = db.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("userid", user.UsersId);
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("fullname", user.FullName);
                HttpContext.Session.SetString("avatar", user.Avatar);
                return Redirect("/Admin/Home/Index");
            }
            ViewBag.error = "<p style='color:red;'>Tên đăng nhập hoặc mật khẩu không đúng!</p>";
            return View(user);
        }
    }
}
