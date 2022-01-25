using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int MaDonHang { get; set; }
        public int? MaKhachHang { get; set; }
        public double? TongTien { get; set; }
        public DateTime? NgayDat { get; set; }
        public string GhiChu { get; set; }

        public virtual Customer MaKhachHangNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
