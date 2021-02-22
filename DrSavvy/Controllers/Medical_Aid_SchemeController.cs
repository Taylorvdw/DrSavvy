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
    public class Medical_Aid_SchemeController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Medical_Aid_Scheme
        public ActionResult Index()
        {
            var medical_Aid_Scheme = db.Medical_Aid_Scheme.Include(m => m.Medical_Aid_Company);
            return View(medical_Aid_Scheme.ToList());
        }

        // GET: Medical_Aid_Scheme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Aid_Scheme medical_Aid_Scheme = db.Medical_Aid_Scheme.Find(id);
            if (medical_Aid_Scheme == null)
            {
                return HttpNotFound();
            }
            return View(medical_Aid_Scheme);
        }

        // GET: Medical_Aid_Scheme/Create
        public ActionResult Create()
        {
            ViewBag.Company_ID = new SelectList(db.Medical_Aid_Company, "Company_ID", "Company_Name");
            return View();
        }

        // POST: Medical_Aid_Scheme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Scheme_ID,Scheme_Name,Company_ID")] Medical_Aid_Scheme medical_Aid_Scheme)
        {
            if (ModelState.IsValid)
            {
                db.Medical_Aid_Scheme.Add(medical_Aid_Scheme);
                db.SaveChanges();
                return new EmptyResult();
            }

            ViewBag.Company_ID = new SelectList(db.Medical_Aid_Company, "Company_ID", "Company_Name", medical_Aid_Scheme.Company_ID);
            return View(medical_Aid_Scheme);
        }

        // GET: Medical_Aid_Scheme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Aid_Scheme medical_Aid_Scheme = db.Medical_Aid_Scheme.Find(id);
            if (medical_Aid_Scheme == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_ID = new SelectList(db.Medical_Aid_Company, "Company_ID", "Company_Name", medical_Aid_Scheme.Company_ID);
            return View(medical_Aid_Scheme);
        }

        // POST: Medical_Aid_Scheme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Scheme_ID,Scheme_Name,Company_ID")] Medical_Aid_Scheme medical_Aid_Scheme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_Aid_Scheme).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            ViewBag.Company_ID = new SelectList(db.Medical_Aid_Company, "Company_ID", "Company_Name", medical_Aid_Scheme.Company_ID);
            return View(medical_Aid_Scheme);
        }

        // GET: Medical_Aid_Scheme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medical_Aid_Scheme medical_Aid_Scheme = db.Medical_Aid_Scheme.Find(id);
            if (medical_Aid_Scheme == null)
            {
                return HttpNotFound();
            }
            return View(medical_Aid_Scheme);
        }

        // POST: Medical_Aid_Scheme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medical_Aid_Scheme medical_Aid_Scheme = db.Medical_Aid_Scheme.Find(id);
            db.Medical_Aid_Scheme.Remove(medical_Aid_Scheme);
            db.SaveChanges();
            return new EmptyResult();
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
