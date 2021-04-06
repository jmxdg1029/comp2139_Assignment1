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
        private CustomerContext custContext { get; set; }
        private ProductContext proContext { get; set; }
        private TechnicianContext tehContext { get; set; }

        public IncidentController(IncidentContext itx, ProductContext ctx, TechnicianContext tctx, CustomerContext cuctx)
        {
            IncidContext = itx;
            proContext = ctx;
            tehContext = tctx;
            custContext = cuctx;

        }
            public IActionResult ManageIncident()
            {
                var customer = custContext.Customers;
                var products = proContext.Products;
                var technician = tehContext.Technicians;

                var incident = IncidContext.Incidents
                        .Include(t => t.Customer)
                        .Include(t => t.Product)
                        .Include(t => t.Technician)

                        .Include(t => t.Technician)
                        .Include(t => t.Product)
                        .Include(t => t.Customer)

                        .OrderBy(t => t.Title)
                        .ToList();
                return View(incident);
            }

            [HttpGet]
            public IActionResult AddIncident()
            {
                ViewBag.Action = "Add";
                ViewBag.Customers = custContext.Customers.OrderBy(c => c.CustomerLastName).ToList();
                ViewBag.Products = proContext.Products.OrderBy(p => p.ProductName).ToList();
                ViewBag.Technicians = tehContext.Technicians.OrderBy(t => t.TechnicianName).ToList();
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
