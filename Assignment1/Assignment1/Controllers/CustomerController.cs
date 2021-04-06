using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
    public class CustomerController : Controller
    {
        private IncidentContext custContext { get; set; }

        public CustomerController(IncidentContext cuctx)
        {
            custContext = cuctx;
        }
        public IActionResult ManageCustomer()
        {
            var customer = custContext.Customers
                .Include(t => t.Country)
                .OrderBy(t => t.CustomerLastName)
                .ToList();
            return View(customer);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = custContext.Countries.OrderBy(c => c.CountryName).ToList();
            return View("EditCustomer", new Customer());
        }
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = custContext.Countries.OrderBy(c => c.CountryName).ToList();
            var customer = custContext.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    custContext.Customers.Add(customer);
                }
                else
                {
                    custContext.Customers.Update(customer);
                }
                custContext.SaveChanges();
                return RedirectToAction("ManageCustomer");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Countries = custContext.Countries.OrderBy(c => c.CountryName).ToList();
                return View(customer);
            }
        }
        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = custContext.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            custContext.Customers.Remove(customer);
            custContext.SaveChanges();
            return RedirectToAction("ManageCustomer");
        }

    }

}