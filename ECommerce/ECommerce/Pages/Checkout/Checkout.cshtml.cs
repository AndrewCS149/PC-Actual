using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class CheckoutModel : PageModel, ISearchTerm
    {
        public IPayment _payment;
        public string Term { get; set; }

        public CheckoutModel(IPayment payment)
        {
            _payment = payment;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            _payment.Run();

            return Page();
        }
    }
}