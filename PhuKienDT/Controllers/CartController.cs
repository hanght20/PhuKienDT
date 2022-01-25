using Microsoft.AspNetCore.Mvc;
using PhuKien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhuKienDT.Models;

namespace PhuKienDT.Controllers
{
    public class CartController : Controller
    {
        PhuKienDTContext db = new PhuKienDTContext();
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            List<CartItem> cart = null;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)
            {
                cart = new List<CartItem>();
                cart.Add(new CartItem { ProductOrder = db.Products.Find(id), SoLuong = 1 });
            }
            else
            {
                cart = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
                CartItem product = cart.SingleOrDefault(x => x.ProductOrder.MaSanPham == id);
                if (product != null)
                {
                    product.SoLuong++;
                }
                else
                    cart.Add(new CartItem { ProductOrder = db.Products.Find(id), SoLuong = 1 });
            }
            HttpContext.Session.Set<List<CartItem>>("Cart", cart);
            return Json(new { total = cart.Sum(x => x.SoLuong) });
        }

        public IActionResult MobileCart()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Order()
        {
            if (HttpContext.Session.Get<Customer>("cus") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<CartItem> cart = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("Cart");
            return View(cart);
        }
        [HttpPost]
        public IActionResult CreateOrder()
        {
            Order order = new Order();
            Customer cus = (Customer)HttpContext.Session.Get<Customer>("customer");
            List<CartItem> cart = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("cart");
            order.MaDonHang = new Random().Next();
            order.MaKhachHang = cus.MaKhachHang;
            double sum = 0;
            foreach (var item in cart)
            {
                sum += item.SoLuong * (double)item.ProductOrder.Gia;
            }
            order.TongTien = sum;
            order.NgayDat = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var item in cart)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OderDetailId = new Random().Next();
                orderDetail.MaSanPham = item.ProductOrder.MaSanPham;
                orderDetail.MaDonHang = order.MaDonHang;
                orderDetail.SoLuong = item.SoLuong;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            HttpContext.Session.Set<List<CartItem>>("cart", null);
            return Redirect("/Cart/OrderConfirm");
        }
        public IActionResult OrderConfirm()
        {
            return View();
        }
    }
}

