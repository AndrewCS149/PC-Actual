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
            await _cart.UpdateTotal(ProductId, cart, cartItem.Quantity, cartItem.Quantity);
            await _cartItems.Delete(cartItem);
            return RedirectToPage("/ShoppingCart/Index");
        }
    }
}