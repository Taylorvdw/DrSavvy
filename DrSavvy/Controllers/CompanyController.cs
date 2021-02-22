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
    public class CompanyController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.Medical_Aid_Company.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Aid_Company medical_Aid_Company = db.Medical_Aid_Company.Find(id);
            if (medical_Aid_Company == null)
            {
                return HttpNotFound();
            }
            return View(medical_Aid_Company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company_ID,Company_Name,ContactPerson,Contact_Number")] Medical_Aid_Company medical_Aid_Company)
        {
            if (ModelState.IsValid)
            {
                db.Medical_Aid_Company.Add(medical_Aid_Company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medical_Aid_Company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Aid_Company medical_Aid_Company = db.Medical_Aid_Company.Find(id);
            if (medical_Aid_Company == null)
            {
                return HttpNotFound();
            }
            return View(medical_Aid_Company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company_ID,Company_Name,ContactPerson,Contact_Number")] Medical_Aid_Company medical_Aid_Company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_Aid_Company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medical_Aid_Company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Aid_Company medical_Aid_Company = db.Medical_Aid_Company.Find(id);
            if (medical_Aid_Company == null)
            {
                return HttpNotFound();
            }
            return View(medical_Aid_Company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medical_Aid_Company medical_Aid_Company = db.Medical_Aid_Company.Find(id);
            db.Medical_Aid_Company.Remove(medical_Aid_Company);
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
