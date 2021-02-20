using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class TechnicianContext : Controller
    {
        private TechnicianContext context { get; set; }
        public IActionResult Index()
        {
            return View();
        }
    }
}
