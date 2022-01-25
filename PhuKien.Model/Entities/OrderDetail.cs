using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class OrderDetail
    {
        public int OderDetailId { get; set; }
        public int? MaSanPham { get; set; }
        public int? MaDonHang { get; set; }
        public int? SoLuong { get; set; }

        public virtual Order MaDonHangNavigation { get; set; }
        public virtual Product MaSanPhamNavigation { get; set; }
    }
}
