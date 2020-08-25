using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class CheckoutModel : PageModel, ISearchTerm
    {
        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public Cart Cart { get; set; }

        [BindProperty]
        public CartItem CartItem { get; set; }

        public string Term { get; set; }
        private readonly IEmail _email;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IPayment _payment;
        private readonly IOrder _order;
        private readonly ICart _cart;

        public CheckoutModel(ICart cart, IOrder order, IPayment payment, UserManager<AppUsers> userManager, IEmail email)
        {
            _cart = cart;
            _order = order;
            _payment = payment;
            _userManager = userManager;
            _email = email;
        }

        public async Task<IActionResult> OnGet()
        {
            if (await _cart.Exists(User.Identity.Name))
            {
                Cart = await _cart.GetCart(User.Identity.Name);
            }
            else if (await _cart.Exists(Request.Cookies["AnonymousUser"]))
            {
                Cart = await _cart.GetCart(Request.Cookies["AnonymousUser"]);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var cart = await _cart.GetCart(Cart.UserEmail);
            Order.Cart = cart;
            if (User.Identity.IsAuthenticated)
            {
                Order.AppUserId = _userManager.GetUserId(User);
            }
            else
            {
                Order.AppUserId = Request.Cookies["AnonymousUser"];
            }
            Order.CartId = cart.Id;
            await _order.Create(Order);

            cart.IsActive = false;
            await _cart.Update(cart);

            _payment.Run(Order);
            //await _cart.Create(Request.Cookies["AnonymousUser"]);

            await _email.SummaryEmail(Order);

            return RedirectToPage("OrderSummary");
        }
    }
}