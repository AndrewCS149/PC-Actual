using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.ShoppingCart
{
    public class DeleteModel : PageModel
    {
        private readonly ICartItems _cartItems;

        public DeleteModel(ICartItems cartItems)
        {
            _cartItems = cartItems;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(CartItem cartItem)
        {
            await _cartItems.Delete(cartItem);
            return RedirectToPage("/ShoppingCart/Index");
        }
    }
}