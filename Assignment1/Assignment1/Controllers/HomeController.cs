using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{

    //Crazy
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private TechnicianContext techContext { get; set; }



        public HomeController(TechnicianContext tctx )
        {
            techContext = tctx;
        }
        public IActionResult Index()
        {
            var technicians = techContext.Technicians
                .OrderBy(t => t.TechnicianName)
                .ToList();
            return View(technicians);
        }

        public IActionResult AddTechnician()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            ViewBag.Message = "Add Product";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
                
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
