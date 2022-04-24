using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FitnessManagementSystem.Data;
using FitnessManagementSystem.Models;

namespace FitnessManagementSystem.Controllers
{
    public class UserLoginsController : Controller
    {
        private FitnessContext db = new FitnessContext();

        // GET: UserLogins
        public ActionResult Index()
        {
            /*return View(db.UserLogins.ToList());*/
            return View();
        }


        // POST: UserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserID,UserName,Password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    Customer obj = db.Customers.Where(a => 
                            a.CustomerEmail.Equals(userLogin.UserName) 
                                    && a.Password.Equals(userLogin.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserName"] = obj.CustomerName.ToString();
                        Session["ID"] = obj.CustomerId.ToString();

                        return RedirectToAction("Profile", new RouteValueDictionary(
                                    new { controller = "Customers", action = "Profile", Id = obj.CustomerId }));
                    }

                    else
                    {
                        ViewBag.Message = "Please enter valid username/password.";
                        return View();
                    }
                }
            }

            return View();
        }

        public new ActionResult Profile(int? id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
