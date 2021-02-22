using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using DrSavvy.Models;
using DrSavvy.ClassModels;
using DrSavvy.Controllers;
using System.Web.Services;

namespace DrSavvy.Controllers
{
    public class ReportController : Controller
    {
        private static List<string> Added2 = new List<string>();

        private static List<string> Added = new List<string>();

        private DrSavvyEntities db = new DrSavvyEntities();


        public ActionResult MainReportView()
        {
            try
            {
                //GENERAL TAB
                //Graphical Report: Appointment Period for the week
                if (DateTime.Today.DayOfWeek.ToString() != "Monday")
                {
                    DateTime FindMonday = DateTime.Today;
                    DateTime FoundMonday = new DateTime();
                    while (FindMonday.DayOfWeek.ToString() != "Monday")
                    {
                        FindMonday = FindMonday.AddDays(-1);
                    }
                    FoundMonday = FindMonday;
                    DateTime Monday = FoundMonday;
                    DateTime Tuesday = FoundMonday.AddDays(1);
                    DateTime Wednesday = FoundMonday.AddDays(2);
                    DateTime Thursday = FoundMonday.AddDays(3);
                    DateTime Friday = FoundMonday.AddDays(4);

                    ViewBag.CountMondayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Monday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountMondayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Monday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountMondayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Monday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountTuesdayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Tuesday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountTuesdayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Tuesday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountTuesdayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Tuesday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountWednesdayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Wednesday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountWednesdayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Wednesday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountWednesdayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Wednesday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountThursdayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Thursday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountThursdayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Thursday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountThursdayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Thursday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountFridayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Friday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountFridayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Friday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountFridayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Friday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();

                }
                else
                {
                    DateTime Monday = DateTime.Today;
                    DateTime Tuesday = DateTime.Today.AddDays(1);
                    DateTime Wednesday = DateTime.Today.AddDays(2);
                    DateTime Thursday = DateTime.Today.AddDays(3);
                    DateTime Friday = DateTime.Today.AddDays(4);

                    ViewBag.CountMondayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Monday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountMondayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Monday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountMondayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Monday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountTuesdayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Tuesday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountTuesdayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Tuesday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountTuesdayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Tuesday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountWednesdayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Wednesday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountWednesdayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Wednesday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountWednesdayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Wednesday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountThursdayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Thursday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountThursdayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Thursday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountThursdayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Thursday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();
                    ViewBag.CountFridayEarlyMorning = db.Appointments.Where(t => t.AppointmentDate.Equals(Friday) && t.Timeslot_ID > 0 && t.Timeslot_ID < 16).Count();
                    ViewBag.CountFridayAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Friday) && t.Timeslot_ID > 15 && t.Timeslot_ID < 20).Count();
                    ViewBag.CountFridayLateAfternoon = db.Appointments.Where(t => t.AppointmentDate.Equals(Friday) && t.Timeslot_ID > 19 && t.Timeslot_ID < 28).Count();

                }

                ViewBag.Employees = db.Employees.Count();
                // ViewBag.SystemUsers = db.Users.Count();
                ViewBag.Suppliers = db.Suppliers.Count();
                ViewBag.Orders = db.Orders.Where(p => p.OS_ID.Equals(2) || p.OS_ID.Equals(3)).Count();



                //PATEINT TAB
                //List of ailmetns for PatientAnalytics dropdown
                if (db.Consultation_Ailment.Where(p => p.Ailment_ID.Equals(p.Ailment.Ailment_ID)).ToList() != null)
                {
                    ViewBag.Ailments = db.Consultation_Ailment.Where(p => p.Ailment_ID.Equals(p.Ailment.Ailment_ID)).ToList();
                }
                else
                {
                    if (db.Ailments.ToList() != null)
                    {
                        ViewBag.Ailments = db.Ailments.ToList();
                    }
                    else
                    {
                        ViewBag.Ailments = null;
                    }
                }
                List<Patient> patlist = db.Patients.ToList();
                return View(patlist);
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        //INVENTORY TAB
            //Inventory Critical Levels
            //Backlog Orders
        //Payments
            //Outstanding Payments
            //Rejected Medical Aid Claims 

        }
        public ActionResult Indexpres(int PatID, int ConID)
        {
            try
                {
                var Patient = db.Patients.Find(PatID);
                ViewBag.Patient = Patient.PatientName + " " + Patient.PatientSurname;
                ViewBag.ConsultationID = ConID;
                ViewBag.PatientID = Patient.Patient_ID;
                ViewBag.PatientName = Patient.PatientName;
                var now = System.DateTime.Now.ToShortDateString();
                ViewBag.Date = now;
                return View();
            }
            catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        public ActionResult Indexmedical(int PatID,int ConID)
        {
            try
            {
                var Patient = db.Patients.Find(PatID);
                ViewBag.Patient = Patient.PatientName + " " + Patient.PatientSurname;
                ViewBag.PatientName = Patient.PatientName;
                ViewBag.PatientID = Patient.Patient_ID;
                ViewBag.Date = System.DateTime.Now.ToString();
                ViewBag.Consultation = ConID;
                Added2.Clear();
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        public ActionResult Indexreferal(int PatID, int ConID)
        {
            var Patient = db.Patients.Find(PatID);
            ViewBag.Patient = Patient.PatientName + " " + Patient.PatientSurname;
            ViewBag.ConsultationID = ConID;
            ViewBag.PatientID = Patient.Patient_ID;
            ViewBag.PatientName = Patient.PatientName;
            ViewBag.PatientIDNum = Patient.PatientIDNum;
            ViewBag.MedicalAid = Patient.Medical_Aid_Scheme.Scheme_Name;
            ViewBag.MedicalAidNo = Patient.MedicalAidNo;
            ViewBag.Cell = Patient.PatientCell;
            ViewBag.Work = Patient.PatientWorkNum;
            ViewBag.Email = Patient.PatientEmail;
            var now = System.DateTime.Today.ToShortDateString();
            ViewBag.Date = now;
            return View();
        }

        [HttpPost]
        public JsonResult AutoComplete2(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var medications = (from medic in db.Medications
                               where medic.Mediction_Description.StartsWith(prefix)
                               select new
                               {
                                   label = medic.Mediction_Description,
                                   val = medic.Medication_ID
                               }).ToList();

            return Json(medications);
        }

        [HttpPost]
        public JsonResult AutoComplete3(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var Ailments = (from ailme in db.Ailments
                               where ailme.Ailment_Name.StartsWith(prefix)
                               select new
                               {
                                   label = ailme.Ailment_Name,
                                   val = ailme.Ailment_ID
                               }).ToList();

            return Json(Ailments);
        }

        [HttpPost]
        public JsonResult AutoComplete4(string prefix)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            var Institute = (from Insti in db.Institutes
                            where Insti.Institute_Name.StartsWith(prefix)
                            select new
                            {
                                label = Insti.Institute_Name,
                                val = Insti.Institute_ID,
                                val1 = Insti.Instsitute_ContactNumber,
                                val2 = Insti.Institute_ContactPerson
                            }).ToList();

            return Json(Institute);
        }

        [WebMethod]
        [HttpPost]
        public JsonResult SaveMedication(int PresID,int ConsID, int MedID, DateTime ValidDate,string Instructions , Prescription_Line Save)
        {
            DateTime Today = DateTime.Today;

            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                {
                    if (Save != null)
                    {
                        Save.Consultation_ID = ConsID;
                        Save.Patient_ID = PresID;
                        Save.Perscription_Date = Today;
                        Save.ValidUntil = ValidDate;
                        Save.Intake = Instructions;
                        Save.Medication_ID = MedID;
                        db.Prescription_Line.Add(Save);
                        db.SaveChanges();
                    }

                }
            }
            var Find = db.Medications.Where(p => p.Medication_ID == Save.Medication_ID).FirstOrDefault().Mediction_Description;
            var list = Find.ToString();
            Added.Add(list);
            db.Configuration.ProxyCreationEnabled = false;
            return new JsonResult { Data = Added, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [WebMethod]
        [HttpPost]
        public JsonResult SaveAilment(string Name)
        {
            var Item = Name.ToString();
            Added2.Add(Item);
            db.Configuration.ProxyCreationEnabled = false;
            return new JsonResult { Data = Added2, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult ClearAilment()
        {
            Added2.Clear();
            return new JsonResult {Data = "success" ,JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult ClearMedical()
        {
            Added.Clear();
            return new JsonResult { Data = "success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult NewPrescription(int PatID)
        {
            var Patient = db.Patients.Find(PatID);
            ViewBag.PatientName = Patient.PatientName + " " + Patient.PatientSurname;
            ViewBag.List = Added;
            return View();
        }

        [HttpPost]
        public ActionResult NewMedical(int PatID, DateTime txtFrom ,DateTime txtTo , DateTime txtResume)
        {
            var Patient = db.Patients.Find(PatID);
            ViewBag.PatientName = Patient.PatientName + " " + Patient.PatientSurname;
            var Date1 = DateTime.Today.ToShortDateString();
            ViewBag.ExaminedDate = Date1;
            ViewBag.From = txtFrom.ToShortDateString();
            ViewBag.To = txtTo.ToShortDateString();
            ViewBag.Resume = txtResume.ToShortDateString();
            ViewBag.List = Added2;
            return View();
        }
        public ActionResult OutstandingReport()
        {
            try
            {
                //int patientid = Convert.ToInt32(TempData["PatientID"]);
                //counter = new List<string>();
                //Patient mypatient = db.Patients.Where(z => z.Patient_ID == patientid).FirstOrDefault();

                List<Product> productlist = db.Products.ToList();
                List<Product_Procedure> pro_proclist = db.Product_Procedure.ToList();
                List<Procedure> procedurelist = db.Procedures.ToList();
                List<Price> pricelist = db.Prices.ToList();
                List<Consultation> conlist = db.Consultations.ToList();
                List<Consultation_Procedure> con_proclist = db.Consultation_Procedure.ToList();
                List<Payment> paymentlist = db.Payments.ToList();
                List<Payment_Type> PayTypeList = db.Payment_Type.ToList();
                List<Medical_Aid_Claim> medclaim = db.Medical_Aid_Claim.ToList();

                var balancelist = from a in pricelist
                                  join b in productlist on a.ProductID equals b.ProductID into table1
                                  from b in table1.DefaultIfEmpty()
                                  join c in pro_proclist on b.ProductID equals c.ProductID into table2
                                  from c in table2.DefaultIfEmpty()
                                  join d in procedurelist on c.Procedure_ID equals d.Procedure_ID into table3
                                  from d in table3.DefaultIfEmpty()
                                  join e in con_proclist on d.Procedure_ID equals e.Procedure_ID into table4
                                  from e in table4.DefaultIfEmpty()
                                  join f in conlist on e.Consultation_ID equals f.Consultation_ID into table5
                                  from f in table5.DefaultIfEmpty()
                                  select new invoicemodel { consultation = f, consultation_procedure = e, procedure = d, product_procedure = c, product = b, price = a };

                List<OutstandingPayments> outstandingpaymentlist = new List<OutstandingPayments>();
                OutstandingPayments outstandingpaymentsobj = new OutstandingPayments();
                List<String> contotal = new List<string>();
                decimal total = 0;
                decimal paidtotal = 0;
                foreach (var Con in conlist)
                {
                    foreach (var conpro in con_proclist.Where(t => t.Consultation_ID.Equals(Con.Consultation_ID)))
                    {
                        foreach (var proproc in pro_proclist.Where(t => t.Procedure_ID.Equals(conpro.Procedure_ID)))
                        {
                            foreach (var prod in productlist.Where(t => t.ProductID.Equals(proproc.ProductID)))
                            {
                                foreach (var price in pricelist.Where(t => t.ProductID.Equals(prod.ProductID)))
                                {

                                    total += price.Price_Figure;
                                }
                            }
                        }
                    }
                    //contotal.Add(Con.Consultation_ID.ToString() + " : " + total.ToString());
                    //outstandingpaymentsobj.ConID = Con.Consultation_ID;
                    //outstandingpaymentsobj.totalconsultation = total;
                    //outstandingpaymentsobj.OwingPatient = Con.Appointment.Patient;

                    foreach (var paytype in PayTypeList)
                    {
                        foreach (var paymnt in paymentlist.Where(p => p.Consultation_ID.Equals(Con.Consultation_ID)))
                        {
                            if (paymnt.Payment_Type.Payment_Type_Description == "Medical Aid")
                            {
                                foreach (var medaidclaim in medclaim.Where(t => t.Payment_ID.Equals(paymnt.Payment_ID)))
                                {
                                    if (medaidclaim.ClaimStatus != "Approved")
                                    {
                                        paidtotal += medaidclaim.Claim_Amount;
                                    }

                                }

                            }
                            if (paymnt.Payment_Type.Payment_Type_Description != "Medical Aid")
                            {
                                paidtotal += paymnt.Payment_Amount;
                            }

                            outstandingpaymentsobj.paymentdetails = paymnt;


                        }
                    }

                    //contotal.Add(Con.Consultation_ID.ToString() + " : " + total.ToString());
                    outstandingpaymentsobj.ConID = Con.Consultation_ID;
                    outstandingpaymentsobj.totalconsultation = total;
                    outstandingpaymentsobj.OwingPatient = Con.Appointment.Patient;
                    outstandingpaymentsobj.amountowing = total - paidtotal;
                    outstandingpaymentlist.Add(outstandingpaymentsobj);
                    paidtotal = 0;
                    total = 0;

                }

                ViewBag.contotal = contotal;

                return View(outstandingpaymentlist);
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        [HttpPost]
        public ActionResult NewRefferal(string PatientName, string txtDate, string IDNumber,string MedicalAid , string MedicalAidNo, string CellNo,string WorkNo,string Email, string txtReason,string ProName,string ProName1,string ProName2)
        {
            try
            {
                ViewBag.PatientName = PatientName;
                ViewBag.Date = txtDate;
                ViewBag.IDNumber = IDNumber;
                ViewBag.Cell = CellNo;
                ViewBag.MedicalAid = MedicalAid;
                ViewBag.MedicalAidNo = MedicalAidNo;
                ViewBag.WorkNo = WorkNo;
                ViewBag.Email = Email;
                ViewBag.Reason = txtReason;
                ViewBag.Institue = ProName;
                ViewBag.InsPerson = ProName2;
                ViewBag.InsNumber = ProName1;
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        //////////////////////////////////////////////////////////

        public ActionResult Index()
        {
            try
            {
                List<Employee> Emp = db.Employees.ToList();
                List<Employee_Role> EmpRole = db.Employee_Role.ToList();

                var combineTable = from a in Emp
                                   join b in EmpRole on a.EMP_Role_ID equals b.EMP_Role_ID into table1
                                   from b in table1.DefaultIfEmpty()
                                   select new EmployeeList { employee = a, employeerole = b };
                return View(combineTable);
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }
        public ActionResult MedicalCertificate()
        {
            try
            {
                List<Patient> Patient = db.Patients.ToList();
                List<Consultation_Ailment> Con_Ailmnt = db.Consultation_Ailment.ToList();
                List<Ailment> ailment = db.Ailments.ToList();
                List<Sick_Note> SNote = db.Sick_Note.ToList();
                List<Consultation> Consult = db.Consultations.ToList();
                List<Appointment> appointments = db.Appointments.ToList();


                //Second iteration of combined tables
                var combineTable = from a in Patient
                                   join b in appointments on a.Patient_ID equals b.Patient_ID into table1
                                   from b in table1.DefaultIfEmpty()
                                   join c in Consult on b.Appointment_ID equals c.Appointment_ID into table2
                                   from c in table2.DefaultIfEmpty()
                                   join d in Con_Ailmnt on c.Consultation_ID equals d.Consultation_ID into table3
                                   from d in table3.DefaultIfEmpty()
                                   join f in SNote on c.Consultation_ID equals f.Consultation_ID into table5
                                   from f in table5.DefaultIfEmpty()
                                   select new MedicalCertificateModel
                                   {
                                       sicknotelist = f,
                                       ConList = c,
                                       Con_Ailment = d,

                                       appointmentlist = b,
                                       PatientList
                                    = a
                                   };

                Patient mypat = db.Patients.Where(z => z.Patient_ID.Equals(2)).FirstOrDefault();
                ViewBag.DateGenerated = System.DateTime.Today;
                ViewBag.Expiry = System.DateTime.Today.AddDays(30);
                ViewBag.UserName = "M.C Mc Donald";
                ViewBag.PatientName = mypat.Title.Title_Description + " " + mypat.PatientName + " " + mypat.PatientSurname;
                ViewBag.Ailments = db.Ailments.Where(tt => tt.Ailment_ID < 3).ToList();
                //viewbag.patientid = tempdata["id"];

                return View(combineTable);
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public ActionResult ExportInventory()
        {
            try
            {
                return new Rotativa.ActionAsPdf("InventoryReport") { FileName = "myInventroyReport.pdf" };
            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }
        public ActionResult InventoryLevel()
        {
            try
            {

                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        public ActionResult InventoryReport()
        {
            try
            {
                List<Product> myproductlist = db.Products.ToList();
                List<Product_Type> myprodtypelist = db.Product_Type.ToList();

                var combineTable = from a in myproductlist
                                   join b in myprodtypelist on a.Product_Type_ID equals b.Product_Type_ID into Table1
                                   from b in Table1.DefaultIfEmpty()
                                   select new ProductCombine { prodlist = a, prodtypelist = b };
                return View(combineTable);



            }
            catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        [HttpPost]
        public ActionResult InventoryReport(int qtylvl = 1)
        {
            try
            {
                ViewBag.Qtylvl = qtylvl;
                List<Product> myproductlist = db.Products.ToList();
                List<Product_Type> myprodtypelist = db.Product_Type.ToList();

                var combineTable = from a in myproductlist
                                   join b in myprodtypelist on a.Product_Type_ID equals b.Product_Type_ID into Table1
                                   from b in Table1.DefaultIfEmpty()
                                   select new ProductCombine { prodlist = a, prodtypelist = b };
                return View(combineTable);

                

            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public List<invoicemodel> invoicez = new List<invoicemodel>();
        [HttpPost]
        public JsonResult GenerateInvoice1(int ConID)
        {
            TempData["Consultationid"] = ConID;
            Consultation pconsult = db.Consultations.Where(t=>t.Consultation_ID.Equals(ConID)).FirstOrDefault();
            int patientid = Convert.ToInt32(pconsult.Patient_ID);
            Patient mypatient = db.Patients.Where(z => z.Patient_ID == patientid).FirstOrDefault();
            ViewBag.DateMade = System.DateTime.Now.Date;
            ViewBag.DateMade = System.DateTime.Now.AddDays(30);
            ViewBag.Name = /*TempData["Name"]*/ mypatient.PatientName;
            ViewBag.Surname = /*TempData["SName"]*/ mypatient.PatientSurname;
            ViewBag.Email = /*TempData["Email"]*/ mypatient.PatientEmail;

            List<Product> productlist = db.Products.ToList();
            List<Product_Procedure> pro_proclist = db.Product_Procedure.ToList();
            List<Procedure> procedurelist = db.Procedures.ToList();
            List<Price> pricelist = db.Prices.ToList();
            List<Consultation> conlist = db.Consultations.ToList();
            List<Consultation_Procedure> con_proclist = db.Consultation_Procedure.ToList();

            var invoice = from a in pricelist
                          join b in productlist on a.ProductID equals b.ProductID into table1
                          from b in table1.DefaultIfEmpty()
                          join c in pro_proclist on b.ProductID equals c.ProductID into table2
                          from c in table2.DefaultIfEmpty()
                          join d in procedurelist on c.Procedure_ID equals d.Procedure_ID into table3
                          from d in table3.DefaultIfEmpty()
                          join e in con_proclist on d.Procedure_ID equals e.Procedure_ID into table4
                          from e in table4.DefaultIfEmpty()
                          join f in conlist on e.Consultation_ID equals f.Consultation_ID into table5
                          from f in table5.DefaultIfEmpty()
                          select new invoicemodel { consultation = f, consultation_procedure = e, procedure = d, product_procedure = c, product = b, price = a };
            int conid = Convert.ToInt32(TempData["ConsultationID"]);
            //   List<invoicemodel> condictionalinvoice = invoice.Where(zz => zz.consultation.Appointment.Patient_ID.Equals(mypatient.Patient_ID)).DefaultIfEmpty().ToList();
            //   List<invoicemodel> generateinvoice = condictionalinvoice.Where(tt => tt.consultation_procedure.Consultation_ID.Equals(ConID)).DefaultIfEmpty().ToList();
            invoicemodel invoiceobj = new invoicemodel();
            foreach (var Con in conlist.Where(c=>c.Consultation_ID.Equals(ConID)))
            {
                foreach (var conpro in con_proclist.Where(t => t.Consultation_ID.Equals(Con.Consultation_ID)))
                {
                    foreach (var proc in procedurelist.Where(i=>i.Procedure_ID.Equals(conpro.Procedure_ID)))
                    {
                        foreach (var proproc in pro_proclist.Where(t => t.Procedure_ID.Equals(proc.Procedure_ID)))
                        {
                            foreach (var prod in productlist.Where(t => t.ProductID.Equals(proproc.ProductID)))
                            {
                                foreach (var price in pricelist.Where(t => t.ProductID.Equals(prod.ProductID)))
                                {
                                    db.Configuration.ProxyCreationEnabled = false;
                                    invoiceobj.consultation = Con;
                                    invoiceobj.consultation_procedure = conpro;
                                    invoiceobj.product_procedure = proproc;
                                    invoiceobj.product = prod;
                                    invoiceobj.procedure = proc;
                                    invoiceobj.price = price;
                                }
                            }
                        }
                    }
                }
            }
            invoicez.Add(invoiceobj);
            return Json(new
            {
                redirectUrl = Url.Action("GenerateInvoice", "Report"),
                isRedirect = true
            });
        }

        public ActionResult GenerateInvoice()
         {
            try
            {
                ViewBag.ConID = TempData["Consultationid"];
                Consultation pconsult = db.Consultations.Where(t => t.Consultation_ID.Equals(TempData["Consultationid"])).FirstOrDefault();
                int patientid = Convert.ToInt32(pconsult.Patient_ID);
                Patient mypatient = db.Patients.Where(z => z.Patient_ID == patientid).FirstOrDefault();
                ViewBag.DateMade = System.DateTime.Now.Date;
                ViewBag.DateDue = System.DateTime.Now.AddDays(30);
                ViewBag.Name = mypatient.PatientName;
                ViewBag.Surname = mypatient.PatientSurname;
                ViewBag.Email = mypatient.PatientEmail;
                ViewBag.Num = mypatient.PatientCell;
            }
            catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }


            return View(invoicez);
         }
        public ActionResult SupplierReport()
        {
            List<Supplier> supplierlist = db.Suppliers.ToList();
            return View(supplierlist);
        }
        public ActionResult Orderslist()
        {
            List<Order> orderlisting = db.Orders.Where(t => t.OS_ID.Equals(2) || t.OS_ID.Equals(3)).ToList();
            ViewBag.ProOrder = db.Order_Line.ToList();
            return View(orderlisting);
        }
        public ActionResult ExportInvoice()
        {
            try
            {
                return new Rotativa.ActionAsPdf("GenerateInvoice") { FileName = "myInvoice" + "-" + System.DateTime.Now.ToShortDateString() + ".pdf" };
            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }
        public ActionResult ExportBloodReq()
        {
            try
            {
                return new Rotativa.ActionAsPdf("BloodTestRequest") { FileName = "BloodTestRequest.pdf" };
            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }
        public ActionResult ExportXrayForm()
        {
            try
            {
                return new Rotativa.ActionAsPdf("XRayForm") { FileName = "XRayForm.pdf" };
            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }
        public ActionResult ExportnalyticsForm()
        {
            try
            {
                return new Rotativa.ActionAsPdf("PatientAnalyticsView") { FileName = "XRayForm.pdf" };
            }
            catch (Exception e)
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }

        public ActionResult OrderView()
        {
            try
            {
                List<Order> orderlist = db.Orders/*.Include(t => t.Supplier.SupplierName).Include(p => p.Order_Status.OS_Description)*/.DefaultIfEmpty().ToList();
                return View(orderlist);
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public ActionResult ExportEmployee()
        {
            try
            {
                return new Rotativa.ActionAsPdf("Index") { FileName = "EmployeeReport" + "-" + System.DateTime.Now.ToShortDateString() + ".pdf"};
            }
            catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }

        public ActionResult OrderBacklog()
        {
            try
            {
                List<OrderClass> Backorderslist = db.Order_Line.Where(x => x.Product.Product_Disable == false && x.Order.Order_Status.OS_Description == "BackOrder").Select(z => new OrderClass { Supplier_ID = z.Order.Supplier_ID, SupplierName = z.Order.Supplier.SupplierName }).Distinct().DefaultIfEmpty().ToList();
                ViewBag.OrderList = new SelectList(Backorderslist, "Supplier_ID", "SupplierName");
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        public ActionResult XRayForm()
        {
            try
            {
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }


        [HttpPost]
        public ActionResult XRayForm(int Patient_ID2, string Xra, string XraTA, string Sonar, string SonarTA, string CT, string CTTA, string MR, string MRTA)
        {
            try { 
            int patientid = Patient_ID2;
            Patient mypatient = db.Patients.Where(z => z.Patient_ID == patientid).FirstOrDefault();
            ViewBag.DateMade = System.DateTime.Now.Date;
            ViewBag.DateMade = System.DateTime.Now.AddDays(30);
            ViewBag.Name = mypatient.PatientName;
            ViewBag.Surname = mypatient.PatientSurname;
            ViewBag.Email = mypatient.PatientEmail;

                ViewBag.Xrashow = "none";
                ViewBag.Sonarshow = "none";
                ViewBag.CTshow = "none";
                ViewBag.MRshow = "none";

                if (Xra != null)
                {
                    ViewBag.Xrashow = "block";
                    if (XraTA != "")
                        ViewBag.XraTA = XraTA;
                    else
                        ViewBag.XraTA = "No Comment";
                }
                if (Sonar != null)
                {
                    ViewBag.Sonarshow = "block";
                    if (SonarTA != "")
                        ViewBag.SonarTA = SonarTA;
                    else
                        ViewBag.SonarTA = "No Comment";
                }
                if (CT != null)
                {
                    ViewBag.CTshow = "block";
                    if (CTTA != "")
                        ViewBag.CTTA = CTTA;
                    else
                        ViewBag.CTTA = "No Comment";
                }
                if (MR != null)
                {
                    ViewBag.MRshow = "block";
                    if (MRTA != "")
                        ViewBag.MRTA = MRTA;
                    else
                        ViewBag.MRTA = "No Comment";

                }

                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        [HttpPost]
        public ActionResult AllBacklogReport()
        {
            try
            {
                List<Order> backlogorders = db.Orders.Where(t => t.OS_ID == 3).DefaultIfEmpty().ToList();

                return View("", backlogorders);
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public ActionResult BacklogReport()
        {
            try
            {
                List<Order> order = db.Orders.ToList();
                ViewBag.ProOrder = db.Order_Line.ToList();
                order = db.Orders.Where(p => p.OS_ID == 3).OrderByDescending(t => t.Order_Date).DefaultIfEmpty().ToList();
                return View(order);
            }
            catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        [HttpPost]
        public ActionResult BacklogReport(DateTime datestart =default(DateTime) , DateTime dateend = default(DateTime), string suppliername = null)
        {
            try
            {
                List<Order> orderlist = db.Orders.ToList();
                ViewBag.ProOrder = db.Order_Line.ToList();
                List<Order> order = new List<Order>();
                if (datestart != null && dateend != null && suppliername != null)
                {
                    order = db.Orders.Where(p => datestart <= p.Order_Date && p.Order_Date <= dateend && p.Supplier.SupplierName == suppliername/*.SupplierName*/ && p.OS_ID == 3).OrderByDescending(t => t.Order_Date).DefaultIfEmpty().ToList();
                }
                if (datestart != null && dateend != null && suppliername == null)
                {
                    order = db.Orders.Where(p => datestart <= p.Order_Date && p.Order_Date <= dateend && p.OS_ID == 3).OrderByDescending(t => t.Order_Date).DefaultIfEmpty().ToList();
                }
                if (order != null)
                {
                    return View(order);
                }
                else
                {
                    return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
                }
            }
            catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
            
        }
        [HttpPost]
        public ActionResult BloodTestRequest(string zero, string one, string two, string three, string four, string five, string six, string seven, string eight, string nine, string ten, string eleven /*bool zero = false, bool one = false, bool two = false, bool three = false,bool four = false, bool five = false, bool six = false, bool seven = false, bool eight = false, bool nine = false, bool ten = false, bool eleven = false*/ )
        {
            try
            {
                ViewBag.showzero = "none";
                ViewBag.showone = "none";
                ViewBag.showtwo = "none";
                ViewBag.showthree = "none";
                ViewBag.showfour = "none";
                ViewBag.showfive = "none";
                ViewBag.showsix = "none";
                ViewBag.showseven = "none";
                ViewBag.showeight = "none";
                ViewBag.shownine = "none";
                ViewBag.showten = "none";
                ViewBag.showeleven = "none";

                if (zero != null)
                {
                    ViewBag.showzero = "block";
                }
                if (one != null)
                {
                    ViewBag.showone = "block";
                }
                if (two != null)
                {
                    ViewBag.showtwo = "block";
                }
                if (three != null)
                {
                    ViewBag.showthree = "block";
                }
                if (four != null)
                {
                    ViewBag.showfour = "block";
                }
                if (five != null)
                {
                    ViewBag.showfive = "block";
                }
                if (six != null)
                {
                    ViewBag.showsix = "block";
                }
                if (seven != null)
                {
                    ViewBag.showseven = "block";
                }
                if (eight != null)
                {
                    ViewBag.showeight = "block";
                }
                if (nine != null)
                {
                    ViewBag.shownine = "block";
                }
                if (ten != null)
                {
                    ViewBag.showten = "block";
                }
                if (eleven != null)
                {
                    ViewBag.showeleven = "block";
                }

                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }

        }
        public ActionResult ErrorPage()
        {
            try
            {
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public ActionResult PatientAnalytics()
        {
            try
            {
                ViewBag.Ailments = db.Consultation_Ailment.Where(p => p.Ailment_ID.Equals(p.Ailment.Ailment_ID)).DefaultIfEmpty().ToList();
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public ActionResult PatientAnalyticsView()
        {
            try
            {
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        [HttpPost]
        public ActionResult PatientAnalyticsView(string gender, string age, string ailment)
        {
            try
            {
                if (gender != null && age != null && ailment != null)
                {
                    List<DateTime> BDay = db.Patients.Where(z => z.Gender == gender).Select(p => p.DOB.Value).DefaultIfEmpty().ToList();
                    int totnumberpat = db.Consultation_Ailment/*.GroupBy(p => p.Consultation.Appointment.Patient.Patient_ID)*/.DefaultIfEmpty().Count();
                    List<int> agelist = new List<int>();
                    int current = DateTime.Now.Year;
                    for (int i = 0; i < BDay.Count; i++)
                    {
                        int a = (current - BDay[i].Year);
                        agelist.Add(a);
                    }

                    if (age == "5-15")
                    {
                        patientAnalyticsData obj = new patientAnalyticsData();
                        obj.PatientAilmentCount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 1 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 15 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        obj.agecount = agelist.Where(t => t > 1 && t < 15).DefaultIfEmpty().Count();
                        int patailcount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 1 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 15 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        ViewBag.Patailcount = patailcount;
                        ViewBag.totnumberpat = totnumberpat;
                        ViewBag.Comment = gender + " patients between " + age + " that have been recorded on the system to have: <br/> <strong> " + ailment + "</strong>";
                    }
                    if (age == "16-35")
                    {
                        patientAnalyticsData obj = new patientAnalyticsData();
                        obj.PatientAilmentCount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 16 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 35 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        obj.agecount = agelist.Where(t => t > 16 && t < 35).DefaultIfEmpty().Count();
                        int patailcount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 16 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 35 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        ViewBag.Percentage = (patailcount / totnumberpat) * 100;
                        ViewBag.Comment = gender + " patients between " + age + " that have been recorded on the system to have: <br/> <strong> " + ailment + "</strong>";
                    }
                    if (age == "36-44")
                    {
                        patientAnalyticsData obj = new patientAnalyticsData();
                        obj.PatientAilmentCount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 36 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 44 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        obj.agecount = agelist.Where(t => t > 36 && t < 44).DefaultIfEmpty().Count();
                        int patailcount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 36 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 44 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        ViewBag.Percentage = (patailcount / totnumberpat) * 100;
                        ViewBag.Comment = gender + " patients between " + age + " that have been recorded on the system to have: <br/> <strong> " + ailment + "</strong>";
                    }
                    if (age == "45+")
                    {
                        patientAnalyticsData obj = new patientAnalyticsData();
                        obj.PatientAilmentCount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 45 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 1000 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        obj.agecount = agelist.Where(t => t > 45 && t < 1000).DefaultIfEmpty().Count();
                        int patailcount = db.Consultation_Ailment.Where(p => p.Consultation.Appointment.Patient.Gender.Equals(gender) && p.Ailment.Ailment_Name.Equals(ailment) && 45 > (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year) && 1000 < (DateTime.Now.Year - p.Consultation.Appointment.Patient.DOB.Value.Year)).DefaultIfEmpty().Count();
                        ViewBag.Percentage = (patailcount / totnumberpat) * 100;
                        ViewBag.Comment = gender + " patients between " + age + " that have been recorded on the system to have: <br/> <strong> " + ailment + "</strong>";
                    }
                }
                else
                {
                    ViewBag.Errormessage = "An error has occured. Please ensure all boxes have been selected";
                }

                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }

        public class patientAnalyticsData
        {
            public int PatientAilmentCount;
            public int agecount;
        }

        public ActionResult Outstanding()
        {
            try
            {
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        public ActionResult RejectedClaims()
        {
            try
            {
                return View();
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
        [HttpPost]
        public ActionResult RejectClaimView(DateTime datefrom, DateTime dateto)
        {
            try
            {
                if (datefrom != null && dateto != null)
                {
                    List<Medical_Aid_Claim> RejectedClaimsList = db.Medical_Aid_Claim.Where(t => t.ClaimStatus.Equals("Rejected") && t.Claim_Date >= datefrom && t.Claim_Date <= dateto).ToList();
                    return View(RejectedClaimsList);
                }
                else if (datefrom != null && dateto != null && db.Medical_Aid_Claim.Where(t => t.ClaimStatus.Equals("Rejected")).ToList() != null)
                {
                    List<Medical_Aid_Claim> RejectedClaimsList = db.Medical_Aid_Claim.Where(t => t.ClaimStatus.Equals("Rejected")).ToList();
                    return View(RejectedClaimsList);
                }
                else
                {
                    List<Medical_Aid_Claim> RejectedClaimsList = null;
                    return View(RejectedClaimsList);
                }
            }catch
            {
                return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
            }
        }
    }
}
