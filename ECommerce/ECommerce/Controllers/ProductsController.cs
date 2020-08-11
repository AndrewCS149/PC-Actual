using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<string> list = new List<string>();
            //string[] strArr = new string[5];
            List<Dictionary<string, string>> Data = new List<Dictionary<string, string>>();
            using (var reader = new StreamReader(@"wwwroot\cereal.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //strArr[0] = values[0];
                    Dictionary<string, string> DataList = new Dictionary<string, string>();
                    DataList.Add("name", values[0]);
                    DataList.Add("calories", values[3]);
                    DataList.Add("protein", values[4]);
                    DataList.Add("fat", values[5]);
                    DataList.Add("carbo", values[8]);
                    Data.Add(DataList);
                }
            }

            List<Products> allProducts = new List<Products>();
            foreach (var item in Data)
            {

                    Products product = new Products()
                    {
                        Name = item["name"],
                        Calories = item["calories"],
                        Protein = item["protein"],
                        Fat = item["fat"],
                        Carbo = item["carbo"]
                    };
                    allProducts.Add(product);
            }
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