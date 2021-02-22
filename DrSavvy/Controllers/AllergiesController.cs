using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using DrSavvy.Models;
using Newtonsoft.Json;
using System.Drawing;

namespace DrSavvy.Controllers
{
    public class AllergiesController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Allergies
        public ActionResult Index()
        {
            return View(db.Allergies.ToList());
        }

        // GET: Allergies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allergy allergy = db.Allergies.Find(id);
            if (allergy == null)
            {
                return HttpNotFound();
            }
            return View(allergy);
        }

        // GET: Allergies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Allergies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Allergy_ID,Allergy_Name")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                db.Allergies.Add(allergy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allergy);
        }

        // GET: Allergies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allergy allergy = db.Allergies.Find(id);
            if (allergy == null)
            {
                return HttpNotFound();
            }
            return View(allergy);
        }

        // POST: Allergies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Allergy_ID,Allergy_Name")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allergy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allergy);
        }

        // GET: Allergies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allergy allergy = db.Allergies.Find(id);
            if (allergy == null)
            {
                return HttpNotFound();
            }
            return View(allergy);
        }

        // POST: Allergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allergy allergy = db.Allergies.Find(id);
            db.Allergies.Remove(allergy);
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

        //[HttpGet]
        //public JsonResult exportAllergies()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;

        //    List<dynamic> listAllergies = new List<dynamic>();
        //    foreach (Allergy allergy in db.Allergies.ToList())
        //    {
        //        dynamic objAllergy = new ExpandoObject();
        //        objAllergy.Allergy_ID = allergy.Allergy_ID;
        //        objAllergy.Allergy_Name = allergy.Allergy_Name;

        //        listAllergies.Add(objAllergy);
        //    }
        //    //var jsonList = JsonConvert.SerializeObject(listAllergies);

        //    //JsonResult result = new JsonResult();
        //    //result.Data = jsonList;
        //    //result.ContentType = "text/plain";
        //    //return result;

        //    return Json(listAllergies, "application/json", JsonRequestBehavior.AllowGet);
        //    //byte[] fileBytes = System.IO.File.ReadAllBytes(jsonList);
        //    //string fileName = "allergies.json";
        //    //return File(jsonList, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //    //HttpResponseMessage.Content = new StringContent(jsonList, System.Text.Encoding.UTF8, "application/json");

        //    //return HttpResponseMessage;
        //}


        public ActionResult exportAllergies()
        {
            List<Allergy> AllergyList = db.Allergies.ToList();
            if (AllergyList.Count > 0)
            {
                var xEle = new XElement("Allergies",
                from allergies in AllergyList
                select new XElement("Allergy",
                new XElement("Allergy_ID", allergies.Allergy_ID),
                new XElement("Allergy_Name", allergies.Allergy_Name)           

                ));
                // HttpContextBase context = HttpContextBase.Response;
                Response.Write(xEle);
                Response.ContentType = "application/xml";
                Response.AppendHeader("Content-Disposition", "attachment; filename=AllergyList.xml");
                Response.End();
            }
            return new EmptyResult();
        }

        [HttpPost]
        //public ActionResult ImportAllergies(HttpPostedFileBase xmlFile)
        //{
        //    if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
        //    {
        //        var xmlPath = Server.MapPath("~/" + xmlFile.FileName);
        //        xmlFile.SaveAs(xmlPath);
        //        XDocument xDoc = XDocument.Load(xmlPath);
        //        List<Allergy> allergies = xDoc.Descendants("allergies").Select
        //            (Allergy => new Allergy
        //            {
        //                Allergy_Name = Allergy.Element("Allergy_Name").Value

        //            }).ToList();

        //        using (DrSavvyEntities db = new DrSavvyEntities())
        //        {
        //            foreach (Allergy allergy in allergies)
        //            {
        //                var v = db.Allergies.Where(a => a.Allergy_ID.Equals(allergy.Allergy_ID)).FirstOrDefault();

        //                if (v != null)
        //                {
        //                    v.Allergy_Name = allergy.Allergy_Name;
        //                }
        //                else
        //                {
        //                    db.Allergies.Add(allergy);
        //                }
        //                db.SaveChanges();
        //            }
        //        }
        //        ViewBag.Success = "File uploaded successfully..";
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Invalid file(Upload xml file only)";
        //    }
        //    return View("Index");
        //}
        public ActionResult ImportAllergies(HttpPostedFileBase xmlfile)
        {
            if (xmlfile.ContentType.Equals("application/xml") || xmlfile.ContentType.Equals("text/xml"))
            {
                var xmlPath = Server.MapPath("~/FileUpload" + xmlfile.FileName);
                xmlfile.SaveAs(xmlPath);
                List<Allergy> allergies = new List<Allergy>();

                //Load the XML file in XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                //Loop through the selected Nodes.
                foreach (XmlNode node in doc.SelectNodes("/Allergies/Allergy"))
                {
                    //Fetch the Node values and assign it to Model.
                    allergies.Add(new Allergy
                    {
                        Allergy_ID = int.Parse(node["Allergy_ID"].InnerText),
                        Allergy_Name = node["Allergy_Name"].InnerText
                    });
                }
                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                    foreach (var i in allergies)
                    {
                        var v = db.Allergies.Where(a => a.Allergy_ID.Equals(i.Allergy_ID)).FirstOrDefault();

                        if (v != null)
                        {
                            v.Allergy_ID = i.Allergy_ID;
                            v.Allergy_Name = i.Allergy_Name;
                            }
                        else
                        {
                            db.Allergies.Add(i);
                        }
                        db.SaveChanges();
                    }
                }
            }
            else
            {

            }
            return RedirectToAction("Index");
        }
    }
}


        //public ActionResult ImportAllergies(HttpPostedFileBase xmlfile)
        //{
        //    if (xmlfile.ContentType.Equals("application/xml") || xmlfile.ContentType.Equals("text/xml"))
        //    {
        //        var xmlPath = Server.MapPath("~/FileUpload" + xmlfile.FileName);
        //        xmlfile.SaveAs(xmlPath);
        //        List<Allergy> Allergies = new List<Allergy>();

        //        //Load the XML file in XmlDocument.
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(xmlPath);

        //        //Loop through the selected Nodes.
        //        foreach (XmlNode node in doc.SelectNodes("Allergies/Allergy"))
        //        {
        //            //Fetch the Node values and assign it to Model.
        //            Allergies.Add(new Allergy
        //            {
        //                Allergy_ID = int.Parse(node["Allergy_ID"].InnerText),
        //                Allergy_Name = node["Allergy_Name"].InnerText
        //            });
        //        }
        //        using (DrSavvyEntities db = new DrSavvyEntities())
        //        {
        //            foreach (var i in Allergies)
        //            {
        //                var v = db.Allergies.Where(a => a.Allergy_ID.Equals(i.Allergy_ID)).FirstOrDefault();

        //                if (v != null)
        //                {
        //                    v.Allergy_ID = i.Allergy_ID;
        //                    v.Allergy_Name = i.Allergy_Name;
                            
        //                }
        //                else
        //                {
        //                    db.Allergies.Add(i);
        //                }
        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //    else
        //    {

        //    }
        //    return RedirectToAction("Index");
        //}
