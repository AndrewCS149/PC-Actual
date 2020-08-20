using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;

namespace ECommerce.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        public ICartItems _cartItems { get; set; }
        public ICart _cart { get; set; }

        public IndexModel(ICart cart, ICartItems cartItems)
        {
            _cartItems = cartItems;
            _cart = cart;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                //  retrieve user's email
                var email = User.Claims.FirstOrDefault(x => x.Type == "Email").ToString();
                email = email.Substring(7);

                // if user does not have a cart, create one
                var cart = await _cart.GetCart(email);
                if (cart == null)
                {
                    await _cart.Create(email);
                }

                // if the cartItem already exists in the user's cart
                var cartItem = await _cartItems.GetCartItem(cart.Id, id);
                if (cartItem != null)
                {
                    await _cartItems.UpdateQty(cart.Id, id);
                }
                else
                {
                    await _cartItems.AddToCart(cart.Id, id);
                }

                // redirect to products page after adding item to cart
                return RedirectToPagePermanent("../Products/Index");
            }

            return Page();
        }
    }
}