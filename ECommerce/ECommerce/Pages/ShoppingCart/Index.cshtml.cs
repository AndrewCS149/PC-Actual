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
        public IProducts _products { get; set; }

        public ICartItems _cartItems { get; set; }
        public ICart _cart { get; set; }

        public IndexModel(ICart cart, IProducts products, ICartItems cartItems)
        {
            _cartItems = cartItems;
            _products = products;
            _cart = cart;
        }

        //public async Task<IActionResult> OnGet(int productId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //  retrieve user's email
        //        var email = User.Claims.FirstOrDefault(x => x.Type == "Email").ToString();
        //        email = email.Substring(7);

        //        // if user does not have a cart, create one
        //        var cart = await _cart.GetCart(email);
        //        if (cart == null)
        //        {
        //            await _cart.Create(email);
        //        }

        //        await _cartItems.AddToCart(cart.Id, productId);

        //        return RedirectToPagePermanent("../Products/Index");
        //    }

        //    return Page();
        //}

        // TODO: summary comment
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

                await _cartItems.AddToCart(cart.Id, id);

                return RedirectToPagePermanent("../Products/Index");
            }

            return Page();
        }
    }
}