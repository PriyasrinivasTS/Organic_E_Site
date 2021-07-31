using JPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JPProject.Controllers
{
    public class OrdersController : Controller
    {
        List<Products> Items = new List<Products>();
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Order()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Order(Products product)
        {

            return View();
        }

        public ActionResult Cart()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Cart(Products product)
        {
           
            Items.Add(product);
            return RedirectToAction("Index", "Products");            
        }
    }
}