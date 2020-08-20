using ECommerce.Models.Interfaces;
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
            var result = await _cart.GetCartItems(4);
            return View(result);
        }
    }
}