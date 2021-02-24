using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentContext IncidContext { get; set; }
        
        public IncidentController (IncidentContext ctx)
        {
            IncidContext = ctx;
        }

        public IActionResult ManageIncident()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddIncident()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var incident = IncidContext.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentId == 0)
                {
                    IncidContext.Incidents.Add(incident);
                }
                else
                {
                    IncidContext.Incidents.Update(incident);
                }
                IncidContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add" : "Edit";
                return View(incident);
            }

        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
