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
    public class InstitutesController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Institutes
        public ActionResult Index()
        {
            var institutes = db.Institutes.Include(i => i.Institute_Type);
            return View(institutes.ToList());
        }

        // GET: Institutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = db.Institutes.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // GET: Institutes/Create
        public ActionResult Create()
        {
            ViewBag.Institute_Type_ID = new SelectList(db.Institute_Type, "Institute_Type_ID", "Institute_Type_Name");
            return View();
        }

        // POST: Institutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Institute_ID,Institute_Name,Institute_Type_ID,Institute_ContactPerson,Instsitute_ContactNumber")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Institutes.Add(institute);
                db.SaveChanges();
                return new EmptyResult();
            }

            ViewBag.Institute_Type_ID = new SelectList(db.Institute_Type, "Institute_Type_ID", "Institute_Type_Name", institute.Institute_Type_ID);
            return View(institute);
        }

        // GET: Institutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = db.Institutes.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            ViewBag.Institute_Type_ID = new SelectList(db.Institute_Type, "Institute_Type_ID", "Institute_Type_Name", institute.Institute_Type_ID);
            return View(institute);
        }

        // POST: Institutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Institute_ID,Institute_Name,Institute_Type_ID,Institute_ContactPerson,Instsitute_ContactNumber")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institute).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            ViewBag.Institute_Type_ID = new SelectList(db.Institute_Type, "Institute_Type_ID", "Institute_Type_Name", institute.Institute_Type_ID);
            return View(institute);
        }

        // GET: Institutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = db.Institutes.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // POST: Institutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institute institute = db.Institutes.Find(id);
            db.Institutes.Remove(institute);
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
