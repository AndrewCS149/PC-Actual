using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Cart
{
    public class UserCartModel : PageModel
    {
        public Products Product { get; set; }
        public string Term { get; set; }
        public IProducts _products { get; set; }

        public UserCartModel(IProducts products)
        {
            _products = products;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Product = await _products.GetProduct(id);
            return Page();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
            }
        }
    }
}