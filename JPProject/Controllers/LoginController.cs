﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JPProject.Models;
using System.Configuration;
using System.Net.Http;


namespace JPProject.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult CreateAccount() 
        {
            return View();
        }

        //[HttpGet]
        ////test
        //public ActionResult Login(Login LoginCredentials)
        //{
        //    Uri uri = new Uri(URL);
        //    Members vmi;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = uri;
        //        var response = client.GetAsync("TblMembers/" + LoginCredentials.Email);
        //        response.Wait();

        //        var result = response.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var job = result.Content.ReadAsAsync<Members>();
        //            job.Wait();
        //            vmi = job.Result;
        //            return View(vmi);
        //        }
        //    }
        //    return View();
        //}
        
        public ActionResult Signin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Signin(Login members)
        {

            Session["User"] = members.Email;

            Uri url = new Uri(URL);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = url;
            var Response = httpClient.GetAsync("TblMembers/" + members.Email);
            Response.Wait();
            var result = Response.Result;

            IEnumerable<Members> mem;
            if (result.IsSuccessStatusCode)
            {
                var job = result.Content.ReadAsAsync<IEnumerable<Members>>();
                job.Wait();
                mem = job.Result;
                return View(mem);
            }

            return RedirectToAction("Index");
        }



        string URL = ConfigurationManager.AppSettings.Get("URI");
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            Uri url = new Uri(URL);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = url;
            var Response = httpClient.GetAsync("TblMembers");
            Response.Wait();
            var result = Response.Result;

            IEnumerable<Members> mem;
            if (result.IsSuccessStatusCode)
            {
                var job = result.Content.ReadAsAsync<IEnumerable<Members>>();
                job.Wait();
                mem = job.Result;
                return View(mem);
            }
            return View();

        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
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
                var response = httpClient.PostAsJsonAsync("TblMembers", members);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
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
            Uri uri = new Uri(URL);
            Members vmi;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.GetAsync("TblMembers/" + id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var job = result.Content.ReadAsAsync<Members>();
                    job.Wait();
                    vmi = job.Result;
                    return View(vmi);
                }
            }
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Members members)
        {
            Uri uri = new Uri(URL);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.PutAsJsonAsync("TblMembers/"+id.ToString(),members);
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
            return View(members);
        }

        // GET: Login/Delete/5
        // [HttpDelete]
        public ActionResult Delete(int id)
        {
            Uri uri = new Uri(URL);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                var response = client.DeleteAsync("TblMembers/" + id.ToString());
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
