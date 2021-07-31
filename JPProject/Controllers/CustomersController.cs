using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JPProject.Models;
using System.Configuration;
using System.Net.Http;

namespace JPProject.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        string URL = ConfigurationManager.AppSettings.Get("URN");
        public ActionResult Signin()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Members members)
        {
            Uri uri = new Uri(URL);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                var response = httpClient.PostAsJsonAsync("Customer", members);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "nothing");
                }
            }

            return RedirectToAction("Create");
        }
    }
}