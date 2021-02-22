using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrSavvy.Models;

namespace DrSavvy.Controllers
{
    public class AdminController : Controller
    {

        private DrSavvyEntities db = new DrSavvyEntities();
        //  Admin Default View
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            try
            {
                var Patients = db.Patients.Count();
                ViewBag.Patients = Patients;
                var Employees = db.Employees.Count();
                ViewBag.Employees = Employees;
                var SystemUsers = db.AspNetUsers.Count();
                ViewBag.SystemUsers = SystemUsers;
                var Suppliers = db.Suppliers.Count();
                ViewBag.Suppleirs = Suppliers;
                var Orders = db.Orders.Count();
                ViewBag.Orders = Orders;
                var Procedures = db.Procedures.Count();
                ViewBag.Procedures = Procedures;
                var Ailments = db.Ailments.Count();
                ViewBag.Ailments = Ailments;
                var Institutes = db.Institutes.Count();
                ViewBag.Institutes = Institutes;
                var Medical = db.Medical_Aid_Company.Count();
                ViewBag.Medical = Medical;
                var Medication = db.Medications.Count();
                ViewBag.Medication = Medication;
                var Inventory = db.Products.Count();
                ViewBag.Inventory = Inventory;
                var Consultation = db.Consultations.Count();
                ViewBag.Consultations = Consultation;
                var Test = db.Tests.Count();
                ViewBag.Tests = Test;
                var Allergies = db.Allergies.Count();
                ViewBag.Allergies = Allergies;
                var Payment = db.Payments.Count();
                ViewBag.Payments = Payment;
            }
            catch(Exception Ex)
            {
                Ex = Server.GetLastError();
                //Log your exception here
                Response.Clear();
                // clear error on server
                Server.ClearError();
                return RedirectToAction("Error", "NoNetwork");
            }
            return View();
        }

        public ActionResult GetPatients()
        {
            db.Configuration.LazyLoadingEnabled = false;
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                var patients = db.Patients.Include(p => p.Medical_Aid_Scheme).Include(p => p.Patient2).Include(p => p.Title);
                return Json(new { data = patients }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Patient());
            else
            {
                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                    return View(db.Patients.Where(x => x.Patient_ID == id).FirstOrDefault<Patient>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Patient pat)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                if (pat.Patient_ID == 0)
                {
                    db.Patients.Add(pat);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(pat).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                Patient pat = db.Patients.Where(x => x.Patient_ID == id).FirstOrDefault<Patient>();
                db.Patients.Remove(pat);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult ProcedureProduct()
        {
            return View();
        }
        public JsonResult AutoComplete(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var procedures = (from prod in db.Procedures
                              where prod.Procedure_Description.StartsWith(prefix)
                              select new
                              {
                                  label = prod.Procedure_Description,
                                  val = prod.Procedure_ID
                              }).ToList();

            return Json(procedures);
        }
        public JsonResult AutoCompletes(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var procedures = (from prod in db.Products
                              where prod.ProductName.StartsWith(prefix)
                              select new
                              {
                                  label = prod.ProductName,
                                  val = prod.ProductID
                              }).ToList();

            return Json(procedures);
        }
        public JsonResult GetProduct(int ProdID)
        {
            using(DrSavvyEntities db = new DrSavvyEntities())
            {
                string proid = db.Products.Where(x => x.ProductID == ProdID).Select(x => x.ProductName).FirstOrDefault();
                return Json(new { id=ProdID,name=proid }, JsonRequestBehavior.AllowGet);
            }           
            
        }
    }
}