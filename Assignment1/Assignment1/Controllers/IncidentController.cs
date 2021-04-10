using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IncidentController(IncidentContext itx)
        {
            IncidContext = itx;
        }
            [Route("/incidents")]
            public IActionResult ManageIncident()
            {
                var customer = IncidContext.Customers;
                var products = IncidContext.Products;
                var technician = IncidContext.Technicians;

                var incident = IncidContext.Incidents
                        .Include(t => t.Customer)
                        .Include(t => t.Product)
                        .Include(t => t.Technician)
                        .OrderBy(t => t.Title)
                        .ToList();

                IncidentViewModel iViewModel = new IncidentViewModel()
                {
                    Incident = incident
                };

                return View(iViewModel);
            }

            [Route("/incidentsU")]
            public IActionResult ManageIncidentU()
                {
                
                    var incident = IncidContext.Incidents
                            .Include(t => t.Customer)
                            .Include(t => t.Product)
                            .Include(t => t.Technician)
                            .OrderBy(t => t.Title)
                            .ToList();
                IncidentViewModel iViewModel = new IncidentViewModel()
                {
                    Incident = incident
                };
                    return View(iViewModel);
                }

            [Route("/incidentsO")]
            public IActionResult ManageIncidentO()
            {
                var incident = IncidContext.Incidents
                        .Include(t => t.Customer)
                        .Include(t => t.Product)
                        .Include(t => t.Technician)
                        .OrderBy(t => t.Title)
                        .ToList();
                IncidentViewModel iViewModel = new IncidentViewModel()
                {
                    Incident = incident
                };
            return View(iViewModel);
            }

            [HttpGet]
            public IActionResult UpdateIncident(int id)
            {
                ViewBag.Action = "Select";
                var incident = IncidContext.Incidents.Find(id);
                return View(incident);
            }

        [HttpGet]
            public IActionResult AddIncident()
            {
                ViewBag.Action = "Add";
                ViewBag.Customers = new SelectList(IncidContext.Customers, "CustomerId", "CustomerFirstName");
                ViewBag.Products = new SelectList(IncidContext.Products, "ProductId", "ProductName");
                ViewBag.Technicians = new SelectList(IncidContext.Technicians, "TechnicianId", "TechnicianName");
                return View("AddIncident", new Incident());
            }
            [HttpPost]
            public IActionResult AddIncident(Incident incident)
            {
                if (ModelState.IsValid)
                {
                    IncidContext.Incidents.Add(incident);
                    IncidContext.SaveChanges();
                    return RedirectToAction("ManageIncident");
                }
            return View(incident);
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
                    TempData["Success"] = incident.Title + " Added Successfully!";
                    IncidContext.Incidents.Add(incident);
                    }
                    else
                    {
                    TempData["Success"] = incident.Title + " Updated Successfully!";
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
        [HttpGet]
        public IActionResult DeleteIncident(int id)
        {
            TempData["Success"] = " Deleted Successfully!";
            var incident = IncidContext.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            IncidContext.Incidents.Remove(incident);
            IncidContext.SaveChanges();
            return RedirectToAction("ManageIncident");
        }

    }
}
