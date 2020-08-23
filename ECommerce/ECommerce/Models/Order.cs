using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}