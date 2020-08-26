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
        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int CartId { get; set; }

        [BindProperty]
        public int Count { get; set; }

        private readonly ICartItems _cartItems;
        private readonly ICart _cart;

        public DeleteModel(ICart cart, ICartItems cartItems)
        {
            _cart = cart;
            _cartItems = cartItems;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(CartItem cartItem)
        {
            await _cart.UpdateTotal(ProductId, CartId, 0, Count);
            await _cartItems.Delete(cartItem);
            return RedirectToPage("/ShoppingCart/Index");
        }
    }
}