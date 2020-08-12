using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ProductsVM
    {
        public List<GraphicsCards> Products { get; set; }
        public string Term { get; set; }
        public string Order { get; set; }
    }
}