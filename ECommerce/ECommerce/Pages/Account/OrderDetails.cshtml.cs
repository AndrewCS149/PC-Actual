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
    public class OrderDetailsModel : PageModel, ISearchTerm
    {
        private readonly IOrder _order;
        private readonly UserManager<AppUsers> _userManager;

        [BindProperty]
        public Order Order { get; set; }

        public string Term { get; set; }

        public OrderDetailsModel(IOrder order, UserManager<AppUsers> userManager)
        {
            _userManager = userManager;
            _order = order;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Order = await _order.GetOrder(_userManager.GetUserId(User), id);
            return Page();
        }
    }
}