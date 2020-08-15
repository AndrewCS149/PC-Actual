using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<AppUsers> _signInManager;

        public LogoutModel(SignInManager<AppUsers> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}