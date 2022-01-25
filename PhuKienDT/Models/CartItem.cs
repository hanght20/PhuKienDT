using PhuKien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhuKienDT.Models
{
   
    public class CartItem
    {
        public Product ProductOrder { get; set; }
        public int SoLuong { get; set; }
    }
}
