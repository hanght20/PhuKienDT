using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    [Serializable]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double? Gia { get; set; }
        public string Anh { get; set; }
        public string MoTa { get; set; }
        public int? MaDanhMuc { get; set; }
        public int? MaNcc { get; set; }

        public virtual Category MaDanhMucNavigation { get; set; }
        public virtual Supplier MaNccNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
