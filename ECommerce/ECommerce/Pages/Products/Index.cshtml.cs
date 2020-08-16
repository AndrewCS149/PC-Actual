using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class ProductsModel : PageModel, ISearchTerm
    {
        private IProducts _products;
        public string Term { get; set; }
        public List<Products> Products { get; set; }

        public ProductsModel(IProducts products)
        {
            _products = products;
        }

        public async Task<IActionResult> OnGet()
        {
            Products = await _products.GetProducts();

            return Page();
        }

        public async Task<IActionResult> OnPost(string term)
        {
            Products = await _products.GetProducts();
            Products = Products.Where(x => x.Name.ToUpper().Contains(term.ToUpper())).ToList();

            return Page();
        }
    }
}