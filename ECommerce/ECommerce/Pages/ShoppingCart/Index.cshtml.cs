using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;

namespace ECommerce.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        public IProducts _products { get; set; }

        public IndexModel(IProducts products)
        {
            _products = products;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            List<Products> cart = new List<Products>();
            var product = await _products.GetProduct(id);
            cart.Add(product);

            return RedirectToPagePermanent("../Products/Index");
        }
    }
}