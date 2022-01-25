using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public bool? GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
