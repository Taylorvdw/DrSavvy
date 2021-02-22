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
using DrSavvy.ClassModels;

namespace DrSavvy.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance
        public ActionResult CapturePayment()
        {
            return View();
        }

        //Capture Payment Controllers
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

        public JsonResult ClientList(int PatientID)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
               
                List<int> ConstID = new List<int>();
                List<string> date = new List<string>();
                List<int> cost = new List<int>();
                List<int> Out = new List<int>();
                ConstID = db.Consultations.Where(x => x.Patient_ID == PatientID).Select(x => x.Consultation_ID).ToList();
                int y = ConstID.Count();
                int i = 0;
                while (i<y)
                {
                    int coss = ConstID[i];
                    date.Add(db.Consultations.Where(x => x.Consultation_ID == coss).Select(x => x.Appointment.AppointmentDate).FirstOrDefault().ToShortDateString());
                    List<int> Proced = new List<int>();
                    Proced = db.Consultation_Procedure.Where(x => x.Consultation_ID == coss).Select(x => x.Procedure_ID).ToList();
                    int d = Proced.Count();
                    int b = 0;
                    List<decimal> Price = new List<decimal>();
                    List<decimal> paid = new List<decimal>();
                    while (b < d)
                    {
                        int proc = Proced[b];
                        List<int> ProdID = new List<int>();
                        ProdID = db.Product_Procedure.Where(x => x.Procedure_ID == proc).Select(x => x.ProductID).ToList();
                        int e = ProdID.Count();
                        int f = 0;                        
                        while (f<e)
                        {
                            int prod = ProdID[f];
                            Price.Add( db.Prices.Where(x=>x.ProductID== prod).Select(x=>x.Price_Figure).FirstOrDefault());
                            f++;
                        }                        
                        b++;
                    }
                    paid = db.Payments.Where(x => x.Consultation_ID == coss).Select(x => x.Payment_Amount).ToList();
                    if (paid.Count() > 0)
                    {
                        Out.Add(Convert.ToInt32(Price.Sum()-paid.Sum()));
                    }
                    else
                    {
                        Out.Add(0);
                    }
                    
                        cost.Add(Convert.ToInt32(Price.Sum()));

                    i++; 
                }

               return Json(new {Con = ConstID, Datatim = date, coCost=cost, pay =Out  }, JsonRequestBehavior.AllowGet);
            }
        }     


        // Invoices Controllers
        public ActionResult Invoices()
        {
            return View();
        }


        public JsonResult PatientList(int PatientID)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {

                List<int> ConstID = new List<int>();
                List<string> date = new List<string>();
                List<int> cost = new List<int>();
                
                ConstID = db.Consultations.Where(x => x.Patient_ID == PatientID).Select(x => x.Consultation_ID).ToList();
                int y = ConstID.Count();
                int i = 0;
                while (i < y)
                {
                    int coss = ConstID[i];
                    date.Add(db.Consultations.Where(x => x.Consultation_ID == coss).Select(x => x.Appointment.AppointmentDate).FirstOrDefault().ToShortDateString());
                    List<int> Proced = new List<int>();
                    Proced = db.Consultation_Procedure.Where(x => x.Consultation_ID == coss).Select(x => x.Procedure_ID).ToList();
                    int d = Proced.Count();
                    int b = 0;
                    List<decimal> Price = new List<decimal>();
                    
                    while (b < d)
                    {
                        int proc = Proced[b];
                        List<int> ProdID = new List<int>();
                        ProdID = db.Product_Procedure.Where(x => x.Procedure_ID == proc).Select(x => x.ProductID).ToList();
                        int e = ProdID.Count();
                        int f = 0;
                        while (f < e)
                        {
                            int prod = ProdID[f];
                            Price.Add(db.Prices.Where(x => x.ProductID == prod).Select(x => x.Price_Figure).FirstOrDefault());
                            f++;
                        }
                        b++;
                    }
                                   
                   cost.Add(Convert.ToInt32(Price.Sum()));
                    i++;
                }
                return Json(new { Con = ConstID, Datatim = date, coCost = cost }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult PaymentType()
        {
            return View();
        }
        public ActionResult MedicalClaim()
        {
            return View();
        }
        //[HttpPost]
        //public JsonResult Print(int COnID)
        //{
            

        //    return Json();
        //}

        //Medical Claim Controllers
        public JsonResult PaiMed(int PatientID)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                List<int> ConstID = new List<int>();
                List<int> MedID = new List<int>();
                List<string> date = new List<string>();
                List<string> Descr = new List<string>();
                List<decimal> Amount = new List<decimal>();
                List<string> status = new List<string>();
                ConstID = db.Consultations.Where(x => x.Patient_ID == PatientID).Select(x => x.Consultation_ID).ToList();
                int coss = ConstID.Count();
                int i = 0;
                List<ClaimClass> Coll = new List<ClaimClass>();
                while (i < coss)
                {
                    int cont = ConstID[i];
                    Coll = db.Medical_Aid_Claim.Where(x => x.Consultation_ID == cont).Select(x => new ClaimClass { Consultation_ID = x.Consultation_ID, ClaimStatus = x.ClaimStatus, Claim_Date = x.Claim_Date, Claim_Amount = x.Claim_Amount, Claim_Description = x.Claim_Description, Medical_Aid_Claim_ID = x.Medical_Aid_Claim_ID, Payment_ID = x.Payment_ID }).ToList();
                    i ++;
                }
                MedID = Coll.Select(x => x.Medical_Aid_Claim_ID).ToList();
                date= Coll.Select(x => x.Claim_Date.ToShortDateString()).ToList();
                Descr= Coll.Select(x => x.Claim_Description).ToList();
                Amount = Coll.Select(x => x.Claim_Amount).ToList();
                status = Coll.Select(x => x.ClaimStatus).ToList();
                return Json(new { MedI = MedID, Datatim = date, coCost = Amount, stat = status, Des = Descr, Con= ConstID }, JsonRequestBehavior.AllowGet);
            }
           
        }

       
    }



}