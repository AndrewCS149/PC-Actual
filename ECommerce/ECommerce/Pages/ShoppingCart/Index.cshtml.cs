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
        public ICartItems _cartItems { get; set; }
        public ICart _cart { get; set; }

        public IndexModel(ICart cart, IProducts products, ICartItems cartItems)
        {
            _cartItems = cartItems;
            _products = products;
            _cart = cart;
        }

        public void OnGet()
        {
        }

        // TODO: summary comment
        public async Task<IActionResult> OnPost(int cartId, int productId)
        {
            if (ModelState.IsValid)
            {
                await _cart.

                return RedirectToPagePermanent("../Products/Index");
            }

            return Page();
        }
    }
}