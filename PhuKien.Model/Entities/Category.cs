using System;
using System.Collections.Generic;

#nullable disable

namespace PhuKien.Model.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
