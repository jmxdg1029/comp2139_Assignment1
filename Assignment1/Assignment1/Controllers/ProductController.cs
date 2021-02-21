using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Assignment1.Controllers
{
    public class ProductContext : Controller
    { 

        public ProductContext ProContext { get; set; }

        public ProductContext(ProductContext ctx)
        {
            ProContext = ctx;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View(new Product());
        }
    }
}
