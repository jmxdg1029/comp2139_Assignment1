using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{//awdawdawd
    public class TechnicianController : Controller
    {
        private IncidentContext tehContext { get; set; }

        public TechnicianController(IncidentContext tctx)
        {
            tehContext = tctx;
        }

        [Route("/technicians")]
        public IActionResult ManageTechnician()
        {
            var technician = tehContext.Technicians
                .OrderBy(t => t.TechnicianName)
                .ToList();
            return View(technician);
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
                return RedirectToAction("ManageTechnician");
            }
            return View(technician);
        }
        [HttpGet]
        public IActionResult EditTechnician(int id)
        {
            ViewBag.Action = "Edit";
            var technician = tehContext.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult EditTechnician(Technician technician)
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
                return RedirectToAction("ManageTechnician");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }
        [HttpGet]
        public IActionResult DeleteTechnician(int id)
        {
            var technician = tehContext.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            tehContext.Technicians.Remove(technician);
            tehContext.SaveChanges();
            return RedirectToAction("ManageTechnician");
        }

    }
}
