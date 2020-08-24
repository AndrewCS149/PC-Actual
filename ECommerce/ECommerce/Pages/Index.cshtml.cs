using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class HomeModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }
        private readonly IProducts _products;

        [BindProperty]
        public List<Products> Products { get; set; }

        public HomeModel(IProducts products)
        {
            _products = products;
        }

        public async Task<IActionResult> OnGet()
        {
            Products = await _products.GetProducts();
            if (Request.Cookies["AnonymousUser"] == null)
            {
                // Create cookie on application startup
                string val = Guid.NewGuid().ToString();
                string key = "AnonymousUser";
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append(key, val, cookie);
            }

            return Page();
        }
    }
}