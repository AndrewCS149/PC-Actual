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
    public class UpdateModel : PageModel
    {
        private readonly ICartItems _cartItems;
        private readonly ICart _cart;

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int CartId { get; set; }

        [BindProperty]
        public int Count { get; set; }

        public UpdateModel(ICart cart, ICartItems cartItems)
        {
            _cart = cart;
            _cartItems = cartItems;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            string email;
            if (User.Identity.IsAuthenticated)
            {
                email = User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            }
            else
            {
                email = Request.Cookies["AnonymousUser"];
            }

            Cart cart = await _cart.GetCart(email);

            var cartItem = await _cartItems.GetCartItem(CartId, ProductId);
            var oldCount = cartItem.Quantity;

            await _cart.UpdateTotal(ProductId, cart, Count, oldCount);
            await _cartItems.UpdateCartQty(Count, CartId, ProductId);

            return RedirectToPage("/ShoppingCart/Index");
        }
    }
}