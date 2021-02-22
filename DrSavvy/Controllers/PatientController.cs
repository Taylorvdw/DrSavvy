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
using Nexmo.Api;


namespace DrSavvy.Controllers
{
    public class PatientController : Controller
    {
        /*-----------------------------------------------------------------Calander CRUD-------------------------------------------------*/

              private DrSavvyEntities db = new DrSavvyEntities();

              public ActionResult BookAppointment()
            {
                return View();
            }
              /*Json Action For Displaying Calander Event as Object*/
              public JsonResult GetAppointments()
            {
                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                var appointments = (from ts in db.Timeslots
                                    join ap in db.Appointments on ts.Timeslot_ID equals ap.Timeslot_ID
                                    join pt in db.Patients on ap.Patient_ID equals pt.Patient_ID
                                    where ap.AppointmentStatus == "Pending"
                                    select new
                                    {
                                        AppointmentID = ap.Appointment_ID,
                                        patient = pt.Patient_ID,
                                        Subject = pt.PatientName + " " + pt.PatientSurname,
                                        Description = ap.AppointmentDescription,
                                        Start = (ap.AppointmentDate + " " + ts.StartTime),
                                        End = (ap.AppointmentDate + " " + ts.EndTime),
                                        Color = ap.ThemeColor,
                                        Allday = ap.IsFullDay,
                                        Date = ap.AppointmentDate.ToString(),
                                        PatientIDNumber = pt.PatientIDNum,
                                    }).ToList();
                    return new JsonResult { Data = appointments, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }

              //checked
              public ActionResult getId()
              {
                  DrSavvyEntities db = new DrSavvyEntities();
                  return Json(db.Patients.Select(x => new
                 {
                PatientID = x.PatientIDNum,
                 }).ToList(), JsonRequestBehavior.AllowGet);
               }
              //checked
              public ActionResult getStart()
              {
            DrSavvyEntities db = new DrSavvyEntities();
            return Json(db.Timeslots.Select(x => new
            {
                StartTim = x.StartTime.ToString()
            }).ToList(), JsonRequestBehavior.AllowGet) ; 
              }
              //checked
              public ActionResult getEnd()
                 {
                   DrSavvyEntities db = new DrSavvyEntities();
                  return Json(db.Timeslots.Select(x => new
                    {
                   EndTim = x.EndTime.ToString()
                   }).ToList(), JsonRequestBehavior.AllowGet);
                 }
              [WebMethod]
              [HttpPost]
              public JsonResult AddP(string Name, string Surname, string IDNum, string CellPhone,string Passport, Patient pat)
        {
            var status = false;
            // apply validation here
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                pat.PatientName = Name;
                pat.PatientSurname = Surname;
                pat.PatientIDNum = IDNum;
                pat.PatientCell = CellPhone;
                pat.PatientPassportNum = Passport;
                db.Patients.Add(pat);
                db.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status } };
        }

              //checked Add Appointment
              [WebMethod]
              [HttpPost]
              public JsonResult AddAppointment(DateTime Date,string PatId,TimeSpan Start,TimeSpan End,string Reason,string Color, Appointment appointment)
                 {
                     var status = false;
                     var Pt = db.Patients.Where(p => p.PatientIDNum == PatId).FirstOrDefault();
                     var Ts = db.Timeslots.Where(p => p.StartTime == Start).FirstOrDefault();
            // apply validation here
            using (DrSavvyEntities db = new DrSavvyEntities())
             {
                appointment.AppointmentDate = Date;
                appointment.Patient_ID = Pt.Patient_ID;
                appointment.Timeslot_ID = Ts.Timeslot_ID;
                appointment.AppointmentDescription = Reason;
                appointment.ThemeColor = Color;
                appointment.AppointmentStatus = "Pending";
                db.Appointments.Add(appointment);
                db.SaveChanges();
                status = true;
                //KEEP THIS VERSION UPON CONFLICT (STORED PROCEDURE)
                db.CreateMobileAppointment("", "", "", "", "", "", appointment.Appointment_ID);
            }


            return new JsonResult { Data = new { status } };
        }
              //checked
              public JsonResult ModifyAppointment(int? id, DateTime Date, string PatId, TimeSpan Start, TimeSpan End, string Reason)
          {
            var status = false;
            var Pt = db.Patients.Where(p => p.PatientIDNum == PatId).FirstOrDefault();
            var Ts = db.Timeslots.Where(p => p.StartTime == Start).FirstOrDefault();
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
               var appointment = db.Appointments.Where(p => p.Appointment_ID == id).FirstOrDefault();
                if (appointment != null)
                {
                    appointment.AppointmentDate = Date;
                    appointment.Patient_ID = Pt.Patient_ID;
                    appointment.Timeslot_ID = Ts.Timeslot_ID;
                    appointment.AppointmentDescription = Reason;
                    db.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status } };
        }
              //checked
              [HttpPost]
              public JsonResult Deleteppointment(int appointmentID)
            {
                var status = false;
                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                    var v = db.Appointments.Where(a => a.Appointment_ID == appointmentID).FirstOrDefault();
                    if (v != null)
                    {
                        db.Appointments.Remove(v);
                        db.SaveChanges();
                        status = true;
                    }
                }
                return new JsonResult { Data = new { status } };
            }
     


        /*--------------------------------------Appointments CRUD-----------------------------------*/

        public ActionResult AllAppointments()
        {
            var appointments = db.Appointments.Include(a => a.Patient).Include(a => a.Timeslot);
            return View(appointments.ToList());
        }

        public ActionResult UpcomingAppointments()
        {
            DateTime currentDay = DateTime.Today;
            var appointments = db.Appointments.Include(a => a.Patient).Include(a => a.Timeslot).Where(a => (a.AppointmentDate) == currentDay || (a.AppointmentDate) > currentDay && (a.AppointmentStatus) == "Pending");
            return View(appointments.ToList());
        }

        // Checked
        public ActionResult DeleteAppointment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // Checked
        [HttpPost, ActionName("DeleteAppointment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("AllAppointments");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        /*--------------------------------------Patients CRUD-----------------------------------*/

        // GET: Patients
        public ActionResult PatientsView()
        {
            List<PatientClass> pat = db.Patients.Where(x => x.PatientHomeAddress == null || x.PatientEmail == null || x.Scheme_ID == null || x.MedicalAidNo == null).Select(x => new PatientClass { Patient_ID = x.Patient_ID, PatientName = x.PatientName, PatientSurname = x.PatientSurname, PatientIDNum = x.PatientIDNum, PatientEmail = x.PatientEmail, DepName = db.Patients.Where(z => z.Patient_ID == x.DependentNo).Select(z => z.PatientName).FirstOrDefault(), Scheme_Name = x.Medical_Aid_Scheme.Scheme_Name, Company_Name = x.Medical_Aid_Scheme.Medical_Aid_Company.Company_Name }).ToList();
            ViewBag.Pat = pat;
            
            return View();
        }

        public ActionResult PatientDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult CreatePatient()
        {
            ViewBag.Scheme_ID = new SelectList(db.Medical_Aid_Scheme, "Scheme_ID", "Scheme_Name");
            ViewBag.DependentNo = new SelectList(db.Patients, "Patient_ID", "PatientName");
            ViewBag.Title_ID = new SelectList(db.Titles, "Title_ID", "Title_Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatient([Bind(Include = "Patient_ID,PatientName,PatientSurname,PatientCell,PatientWorkNum,PatientTelNum,PatientEmail,PatientPoBox,PatientHomeAddress,PatientIDNum,PatientPassportNum,MedicalAidNo,DependentNo,Scheme_ID,Title_ID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("PatientsView");
            }

            ViewBag.Scheme_ID = new SelectList(db.Medical_Aid_Scheme, "Scheme_ID", "Scheme_Name", patient.Scheme_ID);
            ViewBag.DependentNo = new SelectList(db.Patients, "Patient_ID", "PatientName", patient.DependentNo);
            ViewBag.Title_ID = new SelectList(db.Titles, "Title_ID", "Title_Description", patient.Title_ID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult ModifyPatient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Scheme_ID = new SelectList(db.Medical_Aid_Scheme, "Scheme_ID", "Scheme_Name", patient.Scheme_ID);
            ViewBag.DependentNo = new SelectList(db.Patients, "Patient_ID", "PatientName", patient.DependentNo);
            ViewBag.Title_ID = new SelectList(db.Titles, "Title_ID", "Title_Description", patient.Title_ID);
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyPatient([Bind(Include = "Patient_ID,PatientName,PatientSurname,PatientCell,PatientWorkNum,PatientTelNum,PatientEmail,PatientPoBox,PatientHomeAddress,PatientIDNum,PatientPassportNum,MedicalAidNo,DependentNo,Scheme_ID,Title_ID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatientsView");
            }
            ViewBag.Scheme_ID = new SelectList(db.Medical_Aid_Scheme, "Scheme_ID", "Scheme_Name", patient.Scheme_ID);
            ViewBag.DependentNo = new SelectList(db.Patients, "Patient_ID", "PatientName", patient.DependentNo);
            ViewBag.Title_ID = new SelectList(db.Titles, "Title_ID", "Title_Description", patient.Title_ID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult RemovePatient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("RemovePatient")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatientConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("PatientsView");
        }

        //--------------DONT TOUCH----------------------------------
        public JsonResult AutoComplete(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var procedures = (from prod in db.Patients
                              where prod.PatientIDNum.StartsWith(prefix)
                              select new
                              {
                                  label = prod.PatientIDNum,
                                  val = prod.Patient_ID
                              }).ToList();

            return Json(procedures);
        }
        public JsonResult GetPatients(int PatientID)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                Patient pat = new Patient();

                int pid = PatientID;
                string patName = db.Patients.Where(x => x.Patient_ID == PatientID).Select(x => x.PatientName).FirstOrDefault();
                string patSurname = db.Patients.Where(x => x.Patient_ID == PatientID).Select(x => x.PatientSurname).FirstOrDefault();
                string patIDNo = db.Patients.Where(x => x.Patient_ID == PatientID).Select(x => x.PatientIDNum).FirstOrDefault();
                string patEmail = db.Patients.Where(x => x.Patient_ID == PatientID).Select(x => x.PatientEmail).FirstOrDefault();
                int patDep = Convert.ToInt32(db.Patients.Where(x => x.Patient_ID == PatientID).Select(z => z.DependentNo).FirstOrDefault());
                string patDepName = "Null";
                if (patDep != 0)
                {
                     patDepName = db.Patients.Where(x => x.Patient_ID == patDep).Select(x => x.PatientName).FirstOrDefault();
                }
                else
                {
                     patDepName = "None";
                }
                string patMScheme = db.Patients.Where(x => x.Patient_ID == PatientID).Select(x => x.Medical_Aid_Scheme.Scheme_Name).FirstOrDefault();
                string patMComp = db.Patients.Where(x => x.Patient_ID == PatientID).Select(x => x.Medical_Aid_Scheme.Medical_Aid_Company.Company_Name).FirstOrDefault();

                return Json(new { pID = pid, pName = patName, pSName = patSurname, pIDNo = patIDNo, pMail = patEmail, pdName = patDepName, pMS = patMScheme, pMC = patMComp }, JsonRequestBehavior.AllowGet);
            }

                
        }


        public JsonResult DeletePatient(int PatientID)
        {
            using(DrSavvyEntities db=new DrSavvyEntities())
            {
                bool status = false;
                Patient pat = db.Patients.Where(x => x.Patient_ID == PatientID).FirstOrDefault();
                int idd = Convert.ToInt32(pat.DependentNo);
                if (idd == 0)
                {
                    db.Patients.Remove(pat);
                    db.SaveChanges();
                    status = true;
                }
                return Json(status, JsonRequestBehavior.AllowGet);
            }
            
        }


        public ActionResult AddEditPatient(int PatientID)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            List<Title> tit = db.Titles.ToList();
            ViewBag.Titles = new SelectList(tit, "Title_ID", "Title_Description");
            List<Medical_Aid_Scheme> sch = db.Medical_Aid_Scheme.ToList();
            ViewBag.Scheme = new SelectList(sch, "Scheme_ID", "Scheme_Name");
            List<Patient> pa = db.Patients.ToList();
            ViewBag.Patient = new SelectList(pa, "Patient_ID", "PatientIDNum");
            PatientClass model = new PatientClass();
            model.GetAlergyList = db.Allergies.ToList();            
            
            model.GetSchemeList = db.Medical_Aid_Scheme.ToList();
            List<Medical_Aid_Company>comp = db.Medical_Aid_Company.ToList();
            ViewBag.Comp = new SelectList(comp, "Company_ID", "Company_Name");
            

            if (PatientID > 0)
            {

                Patient prod = db.Patients.FirstOrDefault(x => x.Patient_ID == PatientID);
                model.Patient_ID = prod.Patient_ID;
                model.PatientName = prod.PatientName;
                model.PatientEmail = prod.PatientEmail;
                model.PatientHomeAddress = prod.PatientHomeAddress;
                model.PatientCell = prod.PatientCell;
                model.PatientSurname = prod.PatientSurname;
                model.PatientWorkNum = prod.PatientWorkNum;

                if(prod.Title_ID != null)
                {
                    model.Title_Description = prod.Title.Title_Description;
                }
                else
                {
                    model.Title_Description = "";
                }
                
                model.PatientPoBox = prod.PatientPoBox;
                model.MedicalAidNo = prod.MedicalAidNo;
                if (prod.Scheme_ID != null)
                {
                    model.Company_ID = prod.Medical_Aid_Scheme.Company_ID;
                    model.Company_Name = prod.Medical_Aid_Scheme.Medical_Aid_Company.Company_Name;
                    model.Scheme_Name = prod.Medical_Aid_Scheme.Scheme_Name;
                    model.MedicalAidNo = prod.MedicalAidNo;

                }
                else
                {
                    model.Title_Description = "";
                }



                model.DependentNo = prod.DependentNo;
                if (model.DependentNo != null)
                {
                    model.DepSurname = db.Patients.Where(x => x.Patient_ID == model.DependentNo).Select(x => x.PatientSurname).FirstOrDefault();
                    model.DepName= db.Patients.Where(x => x.Patient_ID == model.DependentNo).Select(x => x.PatientName).FirstOrDefault();
                    model.depIDNum= db.Patients.Where(x => x.Patient_ID == model.DependentNo).Select(x => x.PatientIDNum).FirstOrDefault();
                }
                model.PatientIDNum = prod.PatientIDNum;
                model.Alergylist = db.Patient_Allergy_List.Where(x => x.Patient_ID == PatientID).Select(x => x.Allergy_ID).ToArray();
                model.Title_ID = prod.Title_ID;
               
                model.Scheme_ID = prod.Scheme_ID;
            }

            return PartialView("PatientPartial", model);

        }

        public ActionResult GetSchemes(int CompId)
        {
            DrSavvyEntities db = new DrSavvyEntities();

            List<Medical_Aid_Scheme> stateList = db.Medical_Aid_Scheme.Where(x => x.Company_ID == CompId).ToList();

            ViewBag.ProductList = new SelectList(stateList, "Scheme_ID", "Scheme_Name");

            return PartialView("MediOptionPartial");

        }
        public ActionResult GetName(string surname)
        {
            DrSavvyEntities db = new DrSavvyEntities();

            List<Patient> stateList = db.Patients.Where(x => x.PatientSurname == surname).ToList();

            ViewBag.ProductList = new SelectList(stateList, "Patient_ID", "PatientName");

            return PartialView("NameOptionPartial");

        }
        public ActionResult GetsID(int Name)
        {
            DrSavvyEntities db = new DrSavvyEntities();

            List<Patient> stateList = db.Patients.Where(x => x.Patient_ID == Name).ToList();

            ViewBag.ProductList = new SelectList(stateList, "Patient_ID", "PatientIDNum");

            return PartialView("IDPartial");

        }
        public JsonResult AutoCompletess(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var procedures = (from prod in db.Patients
                              where prod.PatientSurname.ToLower().StartsWith(prefix.ToLower())
                              select new
                              {
                                  label = prod.PatientSurname,
                                  val = prod.Patient_ID
                              }).ToList();

            return Json(procedures);
        }
        [HttpPost]
        public ActionResult AddEditPatients(PatientClass model)
        {
            using(DrSavvyEntities db= new DrSavvyEntities())
            {
                bool status = false;
                //if (ModelState.IsValid == true)
                //{
                    if (model.Patient_ID > 0)
                    {
                        Patient pat = db.Patients.FirstOrDefault(x => x.Patient_ID == model.Patient_ID);
                        pat.PatientName = model.PatientName;
                        pat.PatientSurname = model.PatientSurname;
                        pat.PatientCell = model.PatientCell;
                        pat.PatientWorkNum = model.PatientWorkNum;
                        pat.PatientTelNum = model.PatientTelNum;
                        pat.PatientEmail = model.PatientEmail;
                        pat.PatientPoBox = model.PatientPoBox;
                        pat.PatientHomeAddress = model.PatientHomeAddress;
                        pat.PatientIDNum = model.PatientIDNum;
                        pat.Title_ID = model.Title_ID;
                        pat.MedicalAidNo = model.MedicalAidNo;
                        pat.Scheme_ID = model.Scheme_ID;
                        pat.DependentNo = model.DependentNo;
                        db.SaveChanges();
                        if (model.Alergylist != null)
                        {
                            int[] nee = model.Alergylist.ToArray();
                            int[] old = db.Patient_Allergy_List.Where(x => x.Patient_ID == model.Patient_ID).Select(x => x.Allergy_ID).ToArray();

                            IEnumerable<int> diff = model.Alergylist.Except(old);
                            foreach (var a in diff)
                            {
                                Patient_Allergy_List lie = new Patient_Allergy_List();
                                lie.Allergy_ID = a;
                                lie.Patient_ID = model.Patient_ID;
                                db.Patient_Allergy_List.Add(lie);
                                db.SaveChanges();

                            }
                            IEnumerable<int> siff = old.Except(model.Alergylist);
                            foreach (var b in siff)
                            {
                                Patient_Allergy_List lie = new Patient_Allergy_List();
                                lie = db.Patient_Allergy_List.Where(x => x.Patient_ID == model.Patient_ID && x.Allergy_ID == b).FirstOrDefault();
                                db.Patient_Allergy_List.Remove(lie);
                                db.SaveChanges();
                            }
                        }
                           

                        status = true;
                    }
                    else
                    {
                        Patient pat = new Patient();
                        pat.PatientName = model.PatientName;
                        pat.PatientSurname = model.PatientSurname;
                        pat.PatientCell = model.PatientCell;
                        pat.PatientWorkNum = model.PatientWorkNum;
                        pat.PatientTelNum = model.PatientTelNum;
                        pat.PatientEmail = model.PatientEmail;
                        pat.PatientPoBox = model.PatientPoBox;
                        pat.PatientHomeAddress = model.PatientHomeAddress;
                        pat.PatientIDNum = model.PatientIDNum;
                        pat.Title_ID = model.Title_ID;
                        pat.MedicalAidNo = model.MedicalAidNo;
                        pat.Scheme_ID = model.Scheme_ID;
                        pat.DependentNo = model.DependentNo;
                        db.Patients.Add(pat);
                        db.SaveChanges();
                        Patient_Allergy_List ale = new Patient_Allergy_List();
                        if (model.Alergylist != null)
                        {
                            foreach (var a in model.Alergylist)
                            {
                                ale.Allergy_ID = a;
                                ale.Patient_ID = model.Patient_ID;
                                db.Patient_Allergy_List.Add(ale);
                                db.SaveChanges();
                            }
                        }
                        
                        
                        status = true;
                    }
                
                return new JsonResult { Data = new { stat = status } };
            }
        }
    }

}

