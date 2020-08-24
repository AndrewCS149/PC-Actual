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
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _order.Create(Order);

            Order.Cart.IsActive = false;

            await _cart.Update(Order.Cart);

            _payment.Run();

            return Page();
        }
    }
}