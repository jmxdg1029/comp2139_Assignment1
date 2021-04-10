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
                IncidentList = incident,
                CustomerList = IncidContext.Customers.ToList(),
                ProductList = IncidContext.Products.ToList(),
                TechnicianList = IncidContext.Technicians.ToList()
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
                    IncidentList = incident,
                    CustomerList = IncidContext.Customers.ToList(),
                    ProductList = IncidContext.Products.ToList(),
                    TechnicianList = IncidContext.Technicians.ToList()
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
                    IncidentList = incident,
                    CustomerList = IncidContext.Customers.ToList(),
                    ProductList = IncidContext.Products.ToList(),
                    TechnicianList= IncidContext.Technicians.ToList()
                };
            return View(iViewModel);
            }

            [HttpGet]
            public IActionResult TechnicianSelect()
            {
                ViewBag.Action = "Select";
                ViewBag.Technicians = new SelectList(IncidContext.Technicians, "TechnicianId", "TechnicianName");
                return View("TechnicianSelect");
            }
            public IActionResult TechnicianSelectI()
            {
            var incident = IncidContext.Incidents
                    .Include(t => t.Customer)
                    .Include(t => t.Product)
                    .Include(t => t.Technician)
                    .OrderBy(t => t.Title)
                    .ToList();
                return View(incident);
            }

            [HttpGet]
            public IActionResult AddIncident()
            {
                ViewBag.Action = "Add";
                ViewBag.Customers = new SelectList(IncidContext.Customers, "CustomerId", "CustomerFirstName");
                ViewBag.Products = new SelectList(IncidContext.Products, "ProductId", "ProductName");
                ViewBag.Technicians = new SelectList(IncidContext.Technicians, "TechnicianId", "TechnicianName");
                return View("EditIncident", new IncidentViewModel());
            }

            [HttpGet]
            public IActionResult EditIncident(int id)
            {
                ViewBag.Action = "Edit";
                var incidentVM = new IncidentViewModel();
                incidentVM.Incident = IncidContext.Incidents.Find(id);
                ViewBag.Customers = new SelectList(IncidContext.Customers, "CustomerId", "CustomerFirstName");
                ViewBag.Products = new SelectList(IncidContext.Products, "ProductId", "ProductName");
                ViewBag.Technicians = new SelectList(IncidContext.Technicians, "TechnicianId", "TechnicianName");
            return View(incidentVM);
            }

            [HttpPost]
            public IActionResult EditIncident(IncidentViewModel incidentVM)
            {
                if (ModelState.IsValid)
                {
                    if (incidentVM.Incident.IncidentId == 0)
                    {
                    TempData["Success"] = incidentVM.Incident.Title + " Added Successfully!";
                    incidentVM.currPage = "Add";
                    IncidContext.Incidents.Add(incidentVM.Incident);
                    }
                    else
                    {
                    TempData["Success"] = incidentVM.Incident.Title + " Updated Successfully!";
                    incidentVM.currPage = "Edit";
                    IncidContext.Incidents.Update(incidentVM.Incident);
                    }
                    
                    if (incidentVM.Incident.DateClosed == null)
                    {
                        incidentVM.pageVerify = "Open";
                    }
                    else if (incidentVM.Incident.TechnicianId == null)
                    {
                        incidentVM.pageVerify = "Unassigned";
                    }
                    incidentVM.IncidentId = incidentVM.Incident.IncidentId;
                    IncidContext.SaveChanges();
                    return RedirectToAction("ManageIncident");
                }
                else
                {
                    ViewBag.Action = (incidentVM.Incident.IncidentId == 0) ? "Add" : "Edit";
                    return View(incidentVM);
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
