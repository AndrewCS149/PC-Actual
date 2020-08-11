using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using ECommerce.Models.Interfaces;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        public IActionResult Index()
        {
            var allProducts = _products.GetProducts();
            return View(allProducts);
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products products)
        {
            return RedirectToAction("Products", new { products.Name, products.Calories, products.Protein, products.Fat, products.Carbo });
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