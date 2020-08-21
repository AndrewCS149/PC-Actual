using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ICart _cart;

        public ShoppingCartViewComponent(ICart cart)
        {
            _cart = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // get user's email
            string email;
            if (User.Identity.IsAuthenticated)
            {
                var user = User as ClaimsPrincipal;
                email = user.Claims.First(x => x.Type == "Email").Value;
            }
            else
            {
                email = "Default@gmail.com";
            }

            var cart = await _cart.GetCart(email);
            return View(cart);
        }
    }
}