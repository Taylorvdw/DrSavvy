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
    public class Institute_TypeController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Institute_Type
        public ActionResult Index()
        {
            return View(db.Institute_Type.ToList());
        }

        // GET: Institute_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute_Type institute_Type = db.Institute_Type.Find(id);
            if (institute_Type == null)
            {
                return HttpNotFound();
            }
            return View(institute_Type);
        }

        // GET: Institute_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Institute_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Institute_Type_ID,Institute_Type_Name")] Institute_Type institute_Type)
        {
            if (ModelState.IsValid)
            {
                db.Institute_Type.Add(institute_Type);
                db.SaveChanges();
                return new EmptyResult();
            }

            return View(institute_Type);
        }

        // GET: Institute_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute_Type institute_Type = db.Institute_Type.Find(id);
            if (institute_Type == null)
            {
                return HttpNotFound();
            }
            return View(institute_Type);
        }

        // POST: Institute_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Institute_Type_ID,Institute_Type_Name")] Institute_Type institute_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institute_Type).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            return View(institute_Type);
        }

        // GET: Institute_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute_Type institute_Type = db.Institute_Type.Find(id);
            if (institute_Type == null)
            {
                return HttpNotFound();
            }
            return View(institute_Type);
        }

        // POST: Institute_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Institute_Type institute_Type = db.Institute_Type.Find(id);
            db.Institute_Type.Remove(institute_Type);
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
