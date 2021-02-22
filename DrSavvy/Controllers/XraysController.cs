using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using DrSavvy.Models;

namespace DrSavvy.Controllers
{
    public class XraysController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Xrays
        public ActionResult Index(int PatID, int ConID)
        {
            var xrays = db.Xrays.Include(x => x.Consultation).Include(x => x.Patient).Where(p => p.Patient_ID == PatID);
            Patient person = db.Patients.Where(p => p.Patient_ID == PatID).FirstOrDefault();
            ViewBag.Patient = (person.PatientName + " " + person.PatientSurname);
            ViewBag.PatID = PatID;
            ViewBag.ConsID = ConID;
            return View(xrays.ToList());
        }

        public ActionResult Add(int id , int conid)
        {
            ViewBag.Consultation_ID = conid;
            ViewBag.Patient_ID = id;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [WebMethod]

        [HttpPost]
        public JsonResult Upload(string Title, int Patient_ID, int Consultation_ID, Xray xray)
        {
            var httpPostedFile = HttpContext.Request.Files["UploadedImage"];
            if (httpPostedFile != null)
            {
                var fileSavePath = Path.Combine(HttpContext.Server.MapPath("~/Content/XraysFolder"), httpPostedFile.FileName);
                
                // Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(fileSavePath);

                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                    xray.ImagePath = fileSavePath;
                    xray.Title = Title;
                    xray.Patient_ID = Patient_ID;
                    xray.Consultation_ID = Consultation_ID;
                    db.Xrays.Add(xray);
                    db.SaveChanges();
                }
            }
            return Json("Uploaded " + Request.Files.Count + " files", JsonRequestBehavior.AllowGet);
        }






    }
}
