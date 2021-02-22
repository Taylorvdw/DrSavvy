using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using DrSavvy.Models;

namespace DrSavvy.Controllers
{
    public class AilmentsController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Ailments
        public ActionResult Index()
        {
            return View(db.Ailments.ToList());
        }

        // GET: Ailments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ailment ailment = db.Ailments.Find(id);
            if (ailment == null)
            {
                return HttpNotFound();
            }
            return View(ailment);
        }

        // GET: Ailments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ailments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ailment_ID,ICD10,Ailment_Name")] Ailment ailment)
        {
            if (ModelState.IsValid)
            {
                db.Ailments.Add(ailment);
                db.SaveChanges();
                return new EmptyResult();
            }

            return View(ailment);
        }

        // GET: Ailments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ailment ailment = db.Ailments.Find(id);
            if (ailment == null)
            {
                return HttpNotFound();
            }
            return View(ailment);
        }

        // POST: Ailments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ailment_ID,ICD10,Ailment_Name")] Ailment ailment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ailment).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            return View(ailment);
        }

        // GET: Ailments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ailment ailment = db.Ailments.Find(id);
            if (ailment == null)
            {
                return HttpNotFound();
            }
            return View(ailment);
        }

        // POST: Ailments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ailment ailment = db.Ailments.Find(id);
            db.Ailments.Remove(ailment);
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

        public ActionResult exportAilments()
        {
            List<Ailment> AilmentList = db.Ailments.ToList();
            if (AilmentList.Count > 0)
            {
                var xEle = new XElement("Ailments",
                from ailments in AilmentList
                select new XElement("Ailment",
                new XElement("Ailment_ID", ailments.Ailment_ID),
                new XElement("Ailment_Name", ailments.Ailment_Name)

                ));
                // HttpContextBase context = HttpContextBase.Response;
                Response.Write(xEle);
                Response.ContentType = "application/xml";
                Response.AppendHeader("Content-Disposition", "attachment; filename=AilmentList.xml");
                Response.End();
            }
            return new EmptyResult();
        }

        public ActionResult ImportAilment(HttpPostedFileBase xmlfile)
        {
            if (xmlfile.ContentType.Equals("application/xml") || xmlfile.ContentType.Equals("text/xml"))
            {
                var xmlPath = Server.MapPath("~/FileUpload" + xmlfile.FileName);
                xmlfile.SaveAs(xmlPath);
                List<Ailment> ailments = new List<Ailment>();

                //Load the XML file in XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                //Loop through the selected Nodes.
                foreach (XmlNode node in doc.SelectNodes("/Ailments/Ailment"))
                {
                    //Fetch the Node values and assign it to Model.
                    ailments.Add(new Ailment
                    {
                        Ailment_ID = int.Parse(node["Ailment_ID"].InnerText),
                        Ailment_Name = node["Ailment_Name"].InnerText
                    });
                }
                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                    foreach (var i in ailments)
                    {
                        var v = db.Ailments.Where(a => a.Ailment_ID.Equals(i.Ailment_ID)).FirstOrDefault();

                        if (v != null)
                        {
                            v.Ailment_ID = i.Ailment_ID;
                            v.Ailment_Name = i.Ailment_Name;
                        }
                        else
                        {
                            db.Ailments.Add(i);
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
