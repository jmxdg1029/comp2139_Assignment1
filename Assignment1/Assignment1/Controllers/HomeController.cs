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
        private IncidentContext techContext { get; set; }

        public HomeController(IncidentContext tctx)
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
        public IActionResult AddIncident()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
