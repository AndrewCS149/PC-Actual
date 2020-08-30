using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Account
{
    public class OrderHistoryModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }

        [BindProperty]
        public List<Order> Orders { get; set; }

        private readonly IOrder _order;
        private readonly UserManager<AppUsers> _userManager;

        public OrderHistoryModel(UserManager<AppUsers> userManager, IOrder order)

        {
            _userManager = userManager;

            _order = order;
        }

        public async Task<IActionResult> OnGet()
        {
            Orders = await _order.GetOrders(_userManager.GetUserId(User));
            return Page();
        }
    }
}