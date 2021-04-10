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
    public class RegistrationController : Controller
    {
        private IncidentContext regContext { get; set; }

        public RegistrationController(IncidentContext regtx)
        {
            regContext = regtx;
        }

        [HttpGet]
        public IActionResult ManageRegistration()
        {
            ViewBag.Action = "Select";
            ViewBag.Customers = new SelectList(regContext.Customers, "CustomerId", "CustomerFirstName");
            return View("ManageRegistration", new Registration());
        }
        [HttpPost]
        public IActionResult ManageRegistration(Registration registration)
        {
            if(ModelState.IsValid)
                {
                regContext.Registrations.Add(registration);
                regContext.SaveChanges();
                ViewBag.customername = registration;
                return RedirectToAction("AddRegistration");
            }
            return View(registration);
        }

        public IActionResult AddRegistration()
        {
            var customer = regContext.Customers;
            var products = regContext.Products;


            var registration = regContext.Registrations
                    .Include(t => t.Product)
                    .OrderBy(t => t.Product.ProductName)
                    .ToList();

            ViewBag.Products = new SelectList(regContext.Products, "ProductId", "ProductName");
            ViewBag.Action = "Register";
            return View("AddRegistration", new Registration());
        }

        public IActionResult AddRegistration(Registration registration)
        {

            if (ModelState.IsValid)
            {
                regContext.Registrations.Add(registration);
                regContext.SaveChanges();
                return RedirectToAction("ManageRegistration");
            }
            return View(registration);
        }

        [HttpGet]
        public IActionResult DeleteRegistration(int id)
        {
            var registration = regContext.Registrations.Find(id);
            return View(registration);
        }
        [HttpPost]
        public IActionResult Delete(Registration registration)
        {
            regContext.Registrations.Remove(registration);
            regContext.SaveChanges();
            return RedirectToAction("AddRegistration");
        }

    }

}

