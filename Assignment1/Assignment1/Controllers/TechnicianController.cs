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
        private TechnicianContext tehContext { get; set; }

        public TechnicianController(TechnicianContext tctx)
        {
            tehContext = tctx;
        }
        public IActionResult ManageTechnician()
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
                tehContext.Technicians.Add(technician);
                tehContext.SaveChanges();
            }
            return View("ManageTechnician");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = tehContext.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if(ModelState.IsValid)
            {
                if(technician.TechnicianId == 0)
                {
                    tehContext.Technicians.Add(technician);
                }
                else
                {
                    tehContext.Technicians.Update(technician);
                }
                tehContext.SaveChanges();
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
