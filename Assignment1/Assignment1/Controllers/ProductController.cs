    using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {

        private IncidentContext proContext { get; set; }

        public ProductController(IncidentContext ctx)
        {
            proContext = ctx;
        }

        [Route("/products")]
        public IActionResult ManageProduct()
        {
            var product = proContext.Products
                .OrderBy(t => t.ProductName)
                .ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Action = "Add";
            return View("EditProduct", new Product());
            
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ViewBag.Action = "Edit";
            var product = proContext.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    proContext.Products.Add(product);
                    TempData["Success"] = product.ProductName + " Added Successfully!";

                }
                else
                {
                    proContext.Products.Update(product);
                    TempData["Success"] = product.ProductName + " Updated Successfully!";
                }
                proContext.SaveChanges();
                return RedirectToAction("ManageProduct");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
                return View(product);
            }
        }
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = proContext.Products.Find(id);
            TempData["Success"] = " Deleted Successfully!";
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            proContext.Products.Remove(product);
            proContext.SaveChanges();
            return RedirectToAction("ManageProduct");
        }


    }
}
