using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProducts _products;

        public HomeController(IProducts products)
        {
            _products = products;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string term)
        {
            List<Products> products = await _products.GetProducts();
            var results = products.Where(x => x.Name.ToUpper().Contains(term.ToUpper()));

            ProductsVM vm = new ProductsVM
            {
                Products = results.Cast<Products>().ToList(),
                Term = term
            };

            return RedirectToAction("Index", "Products");
            //return View(vm);
        }
    }
}