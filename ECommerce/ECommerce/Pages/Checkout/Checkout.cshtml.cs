using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
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

        public IPayment _payment;
        public IOrder _order;
        public ICart _cart;

        public CheckoutModel(ICart cart, IOrder order, IPayment payment)
        {
            _cart = cart;
            _order = order;
            _payment = payment;
        }

        public async Task<IActionResult> OnGet()
        {
            if(User.Identity.Name != null)
            {
                Cart = await _cart.GetCart(User.Identity.Name);
            }
            else
            {
                Cart = await _cart.GetCart("Default@gmail.com");
            }                
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _order.Create(Order);
            var cart = await _cart.GetCart(Cart.UserEmail);

            cart.IsActive = false;
            await _cart.Update(cart);
            Order.Cart = cart;


            _payment.Run(Order);

            return Page();
        }
    }
}