using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using DrSavvy.Models;
using System.Data.SqlClient;
//using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace DrSavvy.Controllers
{
    public class ConsultationController : Controller
    {
        //Create Link to Database
        private DrSavvyEntities db = new DrSavvyEntities();

        //1st Open Record Consultation Page
        public ActionResult RecordConsultation(int? id, int? pid)
        {

            //Patient Details
            Patient mypatient = db.Patients.Where(z => z.Patient_ID == id).FirstOrDefault();
            ViewBag.PatientName = mypatient.PatientName.ToString();
            ViewBag.PatientSurname = mypatient.PatientSurname.ToString();
            TempData["PatientID"] = id;
            
            ViewBag.PatID = id;
            ViewBag.AppID = pid;
            var Data = db.Patient_Allergy_List.Include(b => b.Allergy).Where(c => c.Patient_ID == id).Distinct().Take(3).ToList();
            return View(Data);

        }
        //2nd Create a New Consultation
        [WebMethod]
        [HttpPost]
        public JsonResult CreateConsultation(int Patient_ID, int Appointment_ID, string Comments, Consultation consultation)
        {
            var Appoint = db.Appointments.Find(Appointment_ID);
            Appoint.AppointmentStatus = "Completed";
            // apply validation here
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                consultation.Patient_ID = Patient_ID;
                consultation.Appointment_ID = Appointment_ID;
                consultation.Comments = Comments;
                db.Consultations.Add(consultation);
                db.SetAppointmentStatus(Appointment_ID);
                db.RemoveMobileAppointment(Appointment_ID);
                db.SaveChanges();
            }
            TempData["ConsultationID"] = consultation.Consultation_ID;
            return Json(consultation.Consultation_ID, JsonRequestBehavior.AllowGet);
        }
        //3rd Find Procedures
        [HttpPost]
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
        //4th Save Consultation Procedures
        [WebMethod]
        [HttpPost]
        public JsonResult AddProcedures(int Consultation_ID, int procid, string procNotes, Consultation_Procedure current)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                current.Consultation_ID = Consultation_ID;
                current.Procedure_ID = procid;
                current.ProcedureNotes = procNotes;
                db.Consultation_Procedure.Add(current);
                db.SaveChanges();
            }
            db.Configuration.ProxyCreationEnabled = false;
            var Added = db.Consultation_Procedure.Where(p => p.Consultation_ID == Consultation_ID);
            return new JsonResult { Data = Added, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //5th Check for Valid Input 
        [HttpPost]
        public JsonResult CheckValidProcedure(int name)
        {
            // find the employee based on the name
            Procedure pro = db.Procedures.Find(name);
            return Json(pro);
        }
        //6th Save Comments
        [HttpPost]
        public JsonResult SaveComment(int Consultation_ID, string Comment)
        {
            var status = false;
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                var Save = db.Consultations.Where(p => p.Consultation_ID == Consultation_ID).FirstOrDefault();
                {
                    if (Save != null)
                    {
                        Save.Comments = Comment;
                        db.SaveChanges();
                    }

                }
            }

            return new JsonResult { Data = new { status } };
        }
        //7th End Consultatuion
        [HttpPost]
        public JsonResult EndConsultation(int Consultation_ID)
        {


            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                db.ReduceInventory(Consultation_ID);
                db.SaveChanges();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

    }
}