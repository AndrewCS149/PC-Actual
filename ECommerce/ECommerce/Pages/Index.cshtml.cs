using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Home
{
    public class HomeModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }

        public void OnGet()
        {
        }
    }
}