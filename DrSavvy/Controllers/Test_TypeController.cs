using DrSavvy.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DrSavvy.Controllers
{
    public class Test_TypeController : Controller
    {
        private DrSavvyEntities db = new DrSavvyEntities();

        // GET: Test_Type
        public ActionResult Index()
        {
            return View(db.Test_Type.ToList());
        }

        // GET: Test_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Type test_Type = db.Test_Type.Find(id);
            if (test_Type == null)
            {
                return HttpNotFound();
            }
            return View(test_Type);
        }

        // GET: Test_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Test_Type_ID,Test_Type_Name,Test_Type_Description")] Test_Type test_Type)
        {
            if (ModelState.IsValid)
            {
                db.Test_Type.Add(test_Type);
                db.SaveChanges();
                return new EmptyResult();
            }

            return View(test_Type);
        }

        // GET: Test_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Type test_Type = db.Test_Type.Find(id);
            if (test_Type == null)
            {
                return HttpNotFound();
            }
            return View(test_Type);
        }

        // POST: Test_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Test_Type_ID,Test_Type_Name,Test_Type_Description")] Test_Type test_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Type).State = EntityState.Modified;
                db.SaveChanges();
                return new EmptyResult();
            }
            return View(test_Type);
        }

        // GET: Test_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Type test_Type = db.Test_Type.Find(id);
            if (test_Type == null)
            {
                return HttpNotFound();
            }
            return View(test_Type);
        }

        // POST: Test_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Type test_Type = db.Test_Type.Find(id);
            db.Test_Type.Remove(test_Type);
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
    }
}
