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
    public class IncrementQtyModel : PageModel
    {
        public ICartItems _cartItems { get; set; }
        public ICart _cart { get; set; }
        public string Term { get; set; }
        public Cart Cart { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int CartId { get; set; }

        [BindProperty]
        public int Count { get; set; }

        public IncrementQtyModel(ICart cart, ICartItems cartItems)
        {
            _cartItems = cartItems;
            _cart = cart;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // check to see if the user is authenticated or not
            string email;
            if (User.Identity.IsAuthenticated)
            {
                email = User.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            }
            else
            {
                email = Request.Cookies["AnonymousUser"];
            }

            var cartItem = await _cartItems.GetCartItem(CartId, ProductId);
            var oldCount = cartItem.Quantity;

            await _cartItems.IncrementQty(CartId, ProductId);
            await _cart.UpdateTotal(ProductId, CartId, Count + 1, oldCount);

            return RedirectToPage("/ShoppingCart/Index");
        }
    }
}