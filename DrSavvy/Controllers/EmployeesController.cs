using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using CrystalDecisions.CrystalReports.Engine;
using DrSavvy.Models;
using System.Data.SqlClient;
using System.Web.Services;

namespace DrSavvy.Controllers
{
    public class EmployeesController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Employee_Role);
            return View(employees.ToList());
        }

        public ActionResult getRole()
        {
            DrSavvyEntities db = new DrSavvyEntities();
            return Json(db.Employee_Role.Select(x => new
            {
                Role = x.Emp_Role_Description,
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [WebMethod]
        [HttpPost]
        public JsonResult AddEmployee(string Name,string ID, string Surname, string Cell, string Email, string Role, Employee pat)
        {
            var status = false;
            var Rola = db.Employee_Role.FirstOrDefault(x => x.Emp_Role_Description == Role);
            // apply validation here
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                pat.EMPName = Name;
                pat.EMPSurname = Surname;
                pat.EMP_Email = Email;
                pat.EMP_CellphoneNum = Cell;
                pat.EMP_Role_ID = Rola.EMP_Role_ID;
                pat.Emp_IDNum = ID;
                db.Employees.Add(pat);
                db.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status } };
        }

        [WebMethod]
        [HttpPost]

        public JsonResult FindEmployee(int ID)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {

                var Employeez = (from emp in db.Employees join  rl in db.Employee_Role on emp.EMP_Role_ID equals rl.EMP_Role_ID where emp.EMP_ID == ID
                                select new
                                {
                                    nAme = emp.EMPName,
                                    SurnAme = emp.EMPSurname,
                                    cEll = emp.EMP_CellphoneNum,
                                    eMail = emp.EMP_Email,
                                    iDnum = emp.Emp_IDNum,
                                    rOle = rl.Emp_Role_Description
                                }).FirstOrDefault();

                return new JsonResult { Data = Employeez, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                ViewBag.EMP_Role_ID = new SelectList(db.Employee_Role, "EMP_Role_ID", "Emp_Role_Description", employee.EMP_Role_ID);
                return PartialView(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMP_ID,EMPName,EMPSurname,EMP_CellphoneNum,EMP_Email,Emp_IDNum,EMP_Role_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            ViewBag.EMP_Role_ID = new SelectList(db.Employee_Role, "EMP_Role_ID", "Emp_Role_Description", employee.EMP_Role_ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch(SqlException ex) when (ex.Number == 547)
            {
                throw ex;
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Employee employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return new EmptyResult();
            }
            catch(SqlException ex)
            {
                throw ex;
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
