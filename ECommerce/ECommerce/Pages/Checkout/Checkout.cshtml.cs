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
        public Order Input { get; set; }

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

        public async Task<IActionResult> OnPost(Order input)
        {
            Order order = new Order()
            {
                LastName = input.LastName,
                FirstName = input.FirstName,
                Address = input.Address,
                City = input.City,
                Zip = input.Zip,
                State = input.State,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                OrderDate = DateTime.Now,
                Cart = input.Cart
            };

            await _order.Create(order);
            order.Cart.IsActive = false;
            await _cart.Update(order.Cart);

            _payment.Run();

            return Page();
        }
    }
}