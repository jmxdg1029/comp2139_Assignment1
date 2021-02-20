using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class TechnicianContext : Controller
    {
        private TechnicianContext Techcontext { get; set; }

        public TechnicianContext(TechnicianContext ctx)
        {
            Techcontext = ctx;
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
