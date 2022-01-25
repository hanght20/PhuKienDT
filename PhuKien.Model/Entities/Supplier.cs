using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
