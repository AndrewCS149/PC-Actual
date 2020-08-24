using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using ECommerce.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerce.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel, ISearchTerm
    {
        [BindProperty]
        public RegisterViewModel Input { get; set; }

        private SignInManager<AppUsers> _signInManager;
        private UserManager<AppUsers> _userManager;
        private IEmail _email;
        public string Term { get; set; }

        public RegisterModel(IEmail email, UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _email = email;
        }

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

                // if registration succeeds, add their full name to claim and redirect to home page
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    await _email.Email(input);
                    Claim claim = new Claim("Fullname", $"{Input.FirstName} {Input.LastName}");
                    Claim claim2 = new Claim("Email", Input.Email);
                    await _userManager.AddClaimAsync(user, claim);
                    await _userManager.AddClaimAsync(user, claim2);

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