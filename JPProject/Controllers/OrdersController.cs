using JPProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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

        [HttpGet]
        public ActionResult Order(int id)
        {
            if(Session["User"] == null)
            {
                return RedirectToAction("Signin", "Customers");
            }
            Orders model = new Orders();
            Uri uri = new Uri(URL);
            Products vmi;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.GetAsync("ProductData/" + id.ToString());
                
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var job = result.Content.ReadAsAsync<Products>();
                    job.Wait();
                    vmi = job.Result;
                    ViewBag.Items = vmi;
                    model.ProductDescription = vmi.ProductDescription;
                    model.ProductName = vmi.ProductName;
                    model.Price = vmi.Price;
                    model.OrderdOn = DateTime.Now;
                    model.CustomerID = Convert.ToInt32(Session["UserID"].ToString());
                    return View(model);
                }
            }

            return View();
        }

        public ActionResult Cart()
        {
            return RedirectToAction("Index", "Products");
            
        }
        string URL = ConfigurationManager.AppSettings.Get("URI");
        [HttpGet]
        public ActionResult Cart(int id)
        {
            Uri uri = new Uri(URL);
            Products vmi;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.GetAsync("ProductData/" + id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var job = result.Content.ReadAsAsync<Products>();
                    job.Wait();
                    vmi = job.Result;
                    Items.Add(vmi);                   
                    return RedirectToAction("Index", "Products");
                }
            }

            return View();

        }
        string URN = ConfigurationManager.AppSettings.Get("URI");
        [HttpPost]
        public ActionResult Order(Orders orders)
        {
            Uri uri = new Uri(URN);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                var response = httpClient.PostAsJsonAsync("OrderData", orders);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["message"] = "Your Order is Placed Successfully...!!";
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("", "nothing");
                }
            }

            return RedirectToAction("Create");
        }

        public ActionResult MyOrders(int id)
        {
            Uri urn = new Uri(URN);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = urn;
            var Response = httpClient.GetAsync("OrderData");
            Response.Wait();
            var result = Response.Result;

            IEnumerable<Orders> mem;
            List<Orders> orders = new List<Orders>();
            if (result.IsSuccessStatusCode)
            {
                var job = result.Content.ReadAsAsync<IEnumerable<Orders>>();
                job.Wait();
                mem = job.Result;
                foreach (var item in mem)
                {
                    if (id == item.CustomerID)
                    {
                        orders.Add(item);
                    }
                }
                return View(orders);
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult MyOrders()
        //{
        //    Uri urn = new Uri(URN);
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.BaseAddress = urn;
        //    var Response = httpClient.GetAsync("OrderData");
        //    Response.Wait();
        //    var result = Response.Result;

        //    IEnumerable<Orders> mem;
        //    List<Orders> orders = new List<Orders>();
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var job = result.Content.ReadAsAsync<IEnumerable<Orders>>();
        //        job.Wait();
        //        mem = job.Result;
                
        //        return View(orders);
        //    }
        //    return View();

        //}

    }
}