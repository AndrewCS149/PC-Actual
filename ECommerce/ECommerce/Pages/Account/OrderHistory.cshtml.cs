using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Account
{
    public class OrderHistoryModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}