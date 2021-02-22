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
    public class Employee_RoleController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Employee_Role
        public ActionResult Index()
        {
            var employee_Role = db.Employee_Role.Include(e => e.Access_Control);
            return View(employee_Role.ToList());
        }

        // GET: Employee_Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Role employee_Role = db.Employee_Role.Find(id);
            if (employee_Role == null)
            {
                return HttpNotFound();
            }
            return View(employee_Role);
        }

        // GET: Employee_Role/Create
        public ActionResult Create()
        {
            ViewBag.AccessID = new SelectList(db.Access_Control, "AccessID", "AC_Name");
            return View();
        }

        // POST: Employee_Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMP_Role_ID,Emp_Role_Description,AccessID")] Employee_Role employee_Role)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Role.Add(employee_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessID = new SelectList(db.Access_Control, "AccessID", "AC_Name", employee_Role.AccessID);
            return View(employee_Role);
        }

        // GET: Employee_Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Role employee_Role = db.Employee_Role.Find(id);
            if (employee_Role == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessID = new SelectList(db.Access_Control, "AccessID", "AC_Name", employee_Role.AccessID);
            return View(employee_Role);
        }

        // POST: Employee_Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMP_Role_ID,Emp_Role_Description,AccessID")] Employee_Role employee_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessID = new SelectList(db.Access_Control, "AccessID", "AC_Name", employee_Role.AccessID);
            return View(employee_Role);
        }

        // GET: Employee_Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Role employee_Role = db.Employee_Role.Find(id);
            if (employee_Role == null)
            {
                return HttpNotFound();
            }
            return View(employee_Role);
        }

        // POST: Employee_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Role employee_Role = db.Employee_Role.Find(id);
            db.Employee_Role.Remove(employee_Role);
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
