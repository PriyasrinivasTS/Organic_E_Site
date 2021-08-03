using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JPProject.Models;
using System.Configuration;
using System.Net.Http;
using System.Web.Security;

namespace JPProject.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        string URL = ConfigurationManager.AppSettings.Get("URI");
        public ActionResult Signin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Signin(Login members)
        {            
            Uri url = new Uri(URL);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = url;
            var Response = httpClient.GetAsync("Customer?EmailID=" + members.Email);
            Response.Wait();
            var result = Response.Result;

            List<Customers> mem = new List<Customers>();
            if (result.IsSuccessStatusCode)
            {
                var job = result.Content.ReadAsAsync<List<Customers>>();
                job.Wait();
                mem = job.Result;
                if (mem.Count == 0)
                {
                    ModelState.AddModelError("Notfound", "User not found, Please do register");                   
                    return View();
                }

                else if ((mem.Any(m => m.Password == members.Password && m.EmailID == members.Email)))
                {
                    var cust = mem.FirstOrDefault(m => m.EmailID == members.Email);
                    Session["UserID"] = cust.CustomerID;
                    Session["User"] = cust.CustomerName;
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("Wrong", "Wrong Credentials");
                    return View();
                }

            }
            else
            {
                ModelState.AddModelError("Try again", "Something went wrong, Try again");
                return View();
            
            }          
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Customers customers)
        {
            Uri uri = new Uri(URL);

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                var Response = httpClient.GetAsync("TblMembers?EmailID=" + customers.EmailID);
                Response.Wait();
                var res = Response.Result;
                List<Customers> cust = new List<Customers>();
                if (res.IsSuccessStatusCode)
                {

                    var job = res.Content.ReadAsAsync<List<Customers>>();
                    job.Wait();
                    cust = job.Result;
                    if (cust.Count != 0)
                    {
                        ModelState.AddModelError("not found", "User Email is already registered, please Sign in");
                        return View();
                    }
                }
                var response = httpClient.PostAsJsonAsync("Customer", customers);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    //ModelState.AddModelError("Registered", "Registered Successfully!!");
                    TempData["SuccessC"] = "Registered Successfully!!";
                    return RedirectToAction("Signin");
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