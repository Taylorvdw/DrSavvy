using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DrSavvy.Models;

namespace DrSavvy.Controllers
{
    public class Order_StatusController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Order_Status
        public ActionResult Index()
        {
            return View(db.Order_Status.ToList());
        }

        // GET: Order_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Status order_Status = db.Order_Status.Find(id);
            if (order_Status == null)
            {
                return HttpNotFound();
            }
            return View(order_Status);
        }

        // GET: Order_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order_Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OS_ID,OS_Description")] Order_Status order_Status)
        {
            if (ModelState.IsValid)
            {
                db.Order_Status.Add(order_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order_Status);
        }

        // GET: Order_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Status order_Status = db.Order_Status.Find(id);
            if (order_Status == null)
            {
                return HttpNotFound();
            }
            return View(order_Status);
        }

        // POST: Order_Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OS_ID,OS_Description")] Order_Status order_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order_Status);
        }

        // GET: Order_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Status order_Status = db.Order_Status.Find(id);
            if (order_Status == null)
            {
                return HttpNotFound();
            }
            return View(order_Status);
        }

        // POST: Order_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Status order_Status = db.Order_Status.Find(id);
            db.Order_Status.Remove(order_Status);
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
