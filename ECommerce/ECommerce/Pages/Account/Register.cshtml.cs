using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel, ISearchTerm
    {
        private SignInManager<AppUsers> _signInManager;
        private UserManager<AppUsers> _userManager;
        public string Term { get; set; }

        public RegisterModel(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        // reserved method name for the loading of this page
        public void OnGet()
        {
        }

        // On registration submission
        public async Task<IActionResult> OnPost(RegisterViewModel input)
        {
            if (ModelState.IsValid)
            {
                AppUsers user = new AppUsers()
                {
                    UserName = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Email = input.Email
                };

                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    Claim claim = new Claim("Fullname", $"{Input.FirstName} {Input.LastName}");
                    await _userManager.AddClaimAsync(user, claim);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToPagePermanent("../Index");
                }
            }

            return Page();
        }

        public class RegisterViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }
        }
    }
}