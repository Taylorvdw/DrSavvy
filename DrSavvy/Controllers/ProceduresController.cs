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
    public class ProceduresController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Procedures
        public ActionResult Index()
        {
            return View(db.Procedures.ToList());
        }

        // GET: Procedures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // GET: Procedures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Procedure_ID,Procedure_Description")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Procedures.Add(procedure);
                db.SaveChanges();
                return new EmptyResult();
            }

            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Procedure_ID,Procedure_Description")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedure).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedure procedure = db.Procedures.Find(id);
            db.Procedures.Remove(procedure);
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

        public ActionResult exportProcedure()
        {
            List<Procedure> ProcedureList = db.Procedures.ToList();
            if (ProcedureList.Count > 0)
            {
                var xEle = new XElement("Procedures",
                from procedures in ProcedureList
                select new XElement("Procedure",
                new XElement("Procedure_ID", procedures.Procedure_ID),
                new XElement("Procedure_Description", procedures.Procedure_Description)

                ));
                // HttpContextBase context = HttpContextBase.Response;
                Response.Write(xEle);
                Response.ContentType = "application/xml";
                Response.AppendHeader("Content-Disposition", "attachment; filename=ProcedureList.xml");
                Response.End();
            }
            return new EmptyResult();
        }

        public ActionResult ImportProcedure(HttpPostedFileBase xmlfile)
        {
            if (xmlfile.ContentType.Equals("application/xml") || xmlfile.ContentType.Equals("text/xml"))
            {
                var xmlPath = Server.MapPath("~/FileUpload" + xmlfile.FileName);
                xmlfile.SaveAs(xmlPath);
                List<Procedure> procedures = new List<Procedure>();

                //Load the XML file in XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                //Loop through the selected Nodes.
                foreach (XmlNode node in doc.SelectNodes("/Procedures/Procedure"))
                {
                    //Fetch the Node values and assign it to Model.
                    procedures.Add(new Procedure
                    {
                        Procedure_ID = int.Parse(node["Procedure_ID"].InnerText),
                        Procedure_Description = node["Procedure_Description"].InnerText
                    });
                }
                using (DrSavvyEntities db = new DrSavvyEntities())
                {
                    foreach (var i in procedures)
                    {
                        var v = db.Procedures.Where(a => a.Procedure_ID.Equals(i.Procedure_ID)).FirstOrDefault();

                        if (v != null)
                        {
                            v.Procedure_ID = i.Procedure_ID;
                            v.Procedure_Description = i.Procedure_Description;
                        }
                        else
                        {
                            db.Procedures.Add(i);
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
