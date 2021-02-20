using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {

        private ProductContext context { set; get; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
