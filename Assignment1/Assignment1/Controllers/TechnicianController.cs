using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class TechnicianController : Controller
    {
        private TechnicianContext Techcontext { get; set; }

        public TechnicianController(TechnicianContext ctx)
        {
            Techcontext = ctx;
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit",new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = Techcontext.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if(ModelState.IsValid)
            {
                if(technician.TechnicianId == 0)
                {
                    Techcontext.Technicians.Add(technician);
                }
                else
                {
                    Techcontext.Technicians.Update(technician);
                }
                Techcontext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
