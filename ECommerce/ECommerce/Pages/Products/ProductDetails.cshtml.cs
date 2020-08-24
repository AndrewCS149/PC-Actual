using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class ProductDetailsModel : PageModel, ISearchTerm
    {
        public Products Product { get; set; }
        public string Term { get; set; }
        public IProducts _products { get; set; }

        public ProductDetailsModel(IProducts products)
        {
            _products = products;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Product = await _products.GetProduct(id);
            return Page();
        }

        public void OnPost()
        {
        }
    }
}