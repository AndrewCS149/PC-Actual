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
        private readonly UserManager<AppUsers> _userManager;

        public ShoppingCartViewComponent(UserManager<AppUsers> userManager, ICart cart)
        {
            _userManager = userManager;
            _cart = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //  retrieve user's email
            var user = User as ClaimsPrincipal;
            var email = user.Claims.First(x => x.Type == "Email").ToString();
            email = email.Substring(7);
            var cart = await _cart.GetCart(email);
            return View(cart);
        }
    }
}