using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessManagementSystem.Data;
using FitnessManagementSystem.Models;

namespace FitnessManagementSystem.Controllers
{
    public class MembershipPlansController : Controller
    {
        private FitnessContext db = new FitnessContext();

        // GET: MembershipPlans
        public ActionResult Index()
        {
            return View(db.MembershipPlans.ToList());
        }

        // GET: MembershipPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPlans membershipPlans = db.MembershipPlans.Find(id);
            if (membershipPlans == null)
            {
                return HttpNotFound();
            }
            return View(membershipPlans);
        }

        // GET: MembershipPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,Name,Description,Price")] MembershipPlans membershipPlans)
        {
            if (ModelState.IsValid)
            {
                db.MembershipPlans.Add(membershipPlans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipPlans);
        }

        // GET: MembershipPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPlans membershipPlans = db.MembershipPlans.Find(id);
            if (membershipPlans == null)
            {
                return HttpNotFound();
            }
            return View(membershipPlans);
        }

        // POST: MembershipPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,Name,Description,Price")] MembershipPlans membershipPlans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipPlans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipPlans);
        }

        // GET: MembershipPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPlans membershipPlans = db.MembershipPlans.Find(id);
            if (membershipPlans == null)
            {
                return HttpNotFound();
            }
            return View(membershipPlans);
        }

        // POST: MembershipPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipPlans membershipPlans = db.MembershipPlans.Find(id);
            db.MembershipPlans.Remove(membershipPlans);
            db.SaveChanges();
            return RedirectToAction("Index");
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
