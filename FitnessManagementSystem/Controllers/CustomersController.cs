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
using PagedList;

namespace FitnessManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        private FitnessContext db = new FitnessContext();

        // GET: Customers
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.customerNameSortParm = String.IsNullOrEmpty(sortOrder) ? "customerName_asc" : "";
            ViewBag.customerphoneSortParm = sortOrder == "customerphone" ? "customerphone_desc" : "customerphone";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var customerList = from s in db.Customers
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                customerList = customerList.Where(s => s.CustomerName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "customerName_asc":
                    customerList = customerList.OrderBy(s => s.CustomerName);

                    break;
                case "customerphone":
                    customerList = customerList.OrderBy(s => s.CustomerPhone);
                    break;
                case "customerphone_desc":
                    customerList = customerList.OrderByDescending(s => s.CustomerPhone);
                    break;
                default:
                    customerList = customerList.OrderBy(s => s.CustomerId);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(customerList.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerName,Password,CustomerEmail,CustomerPhone,CustomerAddress,DateOfBirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Enrollment", 
                    new RouteValueDictionary(new { controller = "Customers",
                                                    action = "Enrollment", 
                                                    Id = customer.CustomerId })
                    );
            }

            return View(customer);
        }


        public ActionResult Enrollment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.customerId = id;
            ViewBag.gymId = new SelectList(db.Gyms, "GymId", "GymStAddress");
            ViewBag.planId = new SelectList(db.MembershipPlans, "PlanId", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enrollment([Bind(Include = "EnrollmentId,PlanId,NumberOfMonths,GymId,CustomerId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Payment", new RouteValueDictionary(
                new { controller = "Customers", action = "Payment", Id = enrollment.EnrollmentId }));
            }
            return View(enrollment);
        }


        public ActionResult Payment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Enrollment enrollment = db.Enrollments.Find(id);
            int month = enrollment.NumberOfMonths;
            MembershipPlans membershipPlan = db.MembershipPlans.Find(enrollment.PlanId);
            int price = membershipPlan.Price;
            int totalamount = month * price;

            ViewBag.enrolementId = id;
            ViewBag.amount = totalamount;
            ViewBag.customerId = enrollment.CustomerId;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment([Bind(Include = "TransactionId,Amount,CardNumber,ExpiryDate,CVV,CustomerId,EnrollmentId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Profile", new RouteValueDictionary(
                new { controller = "Customers", action = "Profile", Id = payment.CustomerId }));
            }

            return View(payment);
        }


        public ActionResult Profile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //   string loggedUsername = Session["UserName"].ToString();
            if (null != Session["UserName"])
            {
                Customer customer = db.Customers.Find(id);
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index", "Customers");
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,Password,CustomerEmail,CustomerPhone,CustomerAddress,DateOfBirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BookSlot()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            ViewBag.BookDate = tomorrow.ToString("d");
            return View();
        }

        public ActionResult SlotNotification(FormCollection coll)
        {
            string loggedUsername = Session["UserName"].ToString();
            int id = Int32.Parse(Session["ID"].ToString());
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            ViewBag.BookDate = tomorrow.ToString("d");

            if (ModelState.IsValid)
            {
                Slots s = new Slots();
                s.CustomerId = id;
                s.Date = tomorrow;
                s.SlotTimeID = coll["slot"].ToString();

                Enrollment e = db.Enrollments.Where(a => a.CustomerId.Equals(id)).FirstOrDefault();

                s.GymId = e.GymId;

                db.Slots.Add(s);
                db.SaveChanges();
                ViewBag.confirm = "Slot is booked.";

                return RedirectToAction("Profile", new RouteValueDictionary(
                new { controller = "Customers", action = "Profile", Id = id }));
            }
            return View();
        }


        public ActionResult BookingHistory()
        {
            int id = Int32.Parse(Session["ID"].ToString());
            var s = db.Slots.Where(a => a.CustomerId.Equals(id));
            if (s != null)
            {
                return View(s);
            }
            else
            {
                ViewBag.message = "No History Found";
                return View();
            }
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
