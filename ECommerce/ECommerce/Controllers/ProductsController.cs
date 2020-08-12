using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using ECommerce.Models.Interfaces;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _products.GetProducts();

            ProductsVM vm = new ProductsVM
            {
                Products = products,
                Term = ""
            };

            return View(vm);
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

            //var currentPage = RouteData.Values["controller"].ToString();

            //if (currentPage != "Products")
            //{
            //    // TODO: not working;
            //    return RedirectToAction("Index", "Products");
            //}

            return View(vm);
        }

        // TODO: not working
        public async Task<IActionResult> DetailsAsync(int id)
        {
            Products product = await _products.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult GetProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProduct()
        {
            return View();
        }
    }
}