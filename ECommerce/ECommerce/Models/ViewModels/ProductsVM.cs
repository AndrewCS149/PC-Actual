using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ProductsVM
    {
        public List<Cereal> Products { get; set; }
        public string Term { get; set; }
        public string Order { get; set; }
    }
}