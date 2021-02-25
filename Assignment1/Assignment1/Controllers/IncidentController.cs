using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var incident = IncidContext.Incidents
                    .OrderBy(t => t.Title)
                    .ToList();
            return View(incident);
        }

        [HttpGet]
        public IActionResult AddIncident()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = IncidContext.Customers.OrderBy(i => i.CustomerLastName).ToList();
            ViewBag.Products = IncidContext.Products.OrderBy(i => i.ProductName).ToList();
            ViewBag.Technicians = IncidContext.Technicians.OrderBy(i => i.TechnicianName).ToList();
            return View("AddIncident", new Incident());
        }

        [HttpGet]
        public IActionResult EditIncident(int id)
        {
            ViewBag.Action = "Edit";
            var incident = IncidContext.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult EditIncident(Incident incident)
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
                return RedirectToAction("ManageIncident");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add" : "Edit";
                return View(incident);
            }

        }
        public IActionResult DeleteIncident(int id)
        {
            var incident = IncidContext.Incidents.Find(id);
            return View(incident);
        }
    }
}
