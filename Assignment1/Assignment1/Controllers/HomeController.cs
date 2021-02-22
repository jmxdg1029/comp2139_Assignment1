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

        public HomeController(TechnicianContext tctx)
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
        public IActionResult ManageTechnician()
        {
            return View();
        }
        public IActionResult AddIncident()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTechnician()
        {
            ViewBag.Action = "Add";
            return View("AddTechnician",new Technician());
        }

        [HttpPost]
        public IActionResult AddTechnician(Technician technician)
        {

            if (ModelState.IsValid)
            {
                techContext.Technicians.Add(technician);
                techContext.SaveChanges();
            }
            return View("Index");
        }

        public IActionResult AddProduct()
        {
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
