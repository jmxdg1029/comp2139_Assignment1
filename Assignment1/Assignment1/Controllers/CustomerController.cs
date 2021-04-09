using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment1.Controllers
{
    public class CustomerController : Controller
    {
        private IncidentContext custContext { get; set; }

        public CustomerController(IncidentContext cuctx)
        {
            custContext = cuctx;
        }
        
        [Route("/customers")]
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
            ViewBag.Countries = new SelectList(custContext.Countries,"CountryId","CountryName");
           
            return View("EditCustomer", new Customer());
        }
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = new SelectList(custContext.Countries, "CountryId", "CountryName");
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
                    TempData["Success"] = customer.CustomerFirstName + " Added Successfully!";
                }
                else
                {
                    custContext.Customers.Update(customer);
                    TempData["Success"] = customer.CustomerFirstName + " Updated Successfully!";
                }
                custContext.SaveChanges();
                return RedirectToAction("ManageCustomer");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Countries = new SelectList(custContext.Countries, "CountryId", "CountryName");
                return View(customer);
            }
        }
        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            TempData["Success"] =  " Deleted Successfully!";
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