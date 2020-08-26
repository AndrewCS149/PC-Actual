using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Checkout
{
    public class OrderSummaryModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }
        private readonly IOrder _order;
        private readonly UserManager<AppUsers> _userManager;

        [BindProperty]
        public Order Order { get; set; }

        public OrderSummaryModel(IOrder order, UserManager<AppUsers> userManager)
        {
            _order = order;
            _userManager = userManager;

        }
        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Order = await _order.GetOrder(_userManager.GetUserId(User));
            }
            else
            {
                Order = await _order.GetOrder(Request.Cookies["AnonymousUser"]);
            }
            return Page();
        }
    }
}