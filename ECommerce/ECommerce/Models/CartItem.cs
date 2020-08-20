using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        public Cart Cart { get; set; }
        public Products Product { get; set; }
    }
}