using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int ProductsId { get; set; }

        public Cart Cart { get; set; }
        public Products Product { get; set; }
    }
}