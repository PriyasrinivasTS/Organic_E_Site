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
    public class ProductsController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        //test
        public ActionResult Login(Login LoginCredentials)
        {
            Uri uri = new Uri(URN);
            Products vmi;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.GetAsync("ProductData/" + LoginCredentials.Email);
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var job = result.Content.ReadAsAsync<Products>();
                    job.Wait();
                    vmi = job.Result;
                    return View(vmi);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login(string email, string password)
        {

            return View();
        }

        string URN = ConfigurationManager.AppSettings.Get("URI") + "ProductData";
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {

            Uri urn = new Uri(URN);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = urn ;
            var Response = httpClient.GetAsync("ProductData");
            if (Session["PartnerID"]!= null)
            {
                 Response = httpClient.GetAsync("ProductData?PartnerID=" + Session["PartnerID"]);
            }
            
            Response.Wait();
            var result = Response.Result;

            IEnumerable<Products> mem;
            if (result.IsSuccessStatusCode)
            {
                var job = result.Content.ReadAsAsync<IEnumerable<Products>>();
                job.Wait();
                mem = job.Result;
                return View(mem);
            }
            return View();

        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            Uri uri = new Uri(URN);
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
                    return View(vmi);
                }
            }
                return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Products Products)
        {
            Uri uri = new Uri(URN);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                Products model = new Products();
                var response = httpClient.PostAsJsonAsync("ProductData", Products);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {                    
                    TempData["Sellermessage"] = "Your Product is added Successfully...!!";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "nothing");
                }
            }

            return RedirectToAction("Create");
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            Uri uri = new Uri(URN);
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
                    return View(vmi);
                }
            }
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products Products)
        {
            Uri uri = new Uri(URN);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.PutAsJsonAsync("ProductData/" + id.ToString(), Products);
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("", "failed to edit");
                }

            }
            return View(Products);
        }

        // GET: Login/Delete/5
        // [HttpDelete]
        public ActionResult Delete(int id)
        {
            Uri uri = new Uri(URN);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.DeleteAsync("ProductData/" + id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
        }

    }
}
