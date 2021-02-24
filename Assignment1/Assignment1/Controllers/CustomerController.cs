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
        private CustomerContext custContext { get; set; }

        public CustomerController(CustomerContext cuctx)
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
            return View("AddCustomer", new Customer());
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {

            if (ModelState.IsValid)
            {
                custContext.Customers.Add(customer);
                custContext.SaveChanges();
            }
            return RedirectToAction("ManageCustomer");
        }
       
    }
}
