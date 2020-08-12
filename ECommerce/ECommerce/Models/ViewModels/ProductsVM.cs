using ECommerce.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ProductsVM : ISearchTerm
    {
        public List<Products> Products { get; set; }
        public string Term { get; set; }
    }
}