using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrSavvy.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Unexpected()
        {
            return View();
        }
        public ActionResult NoNetwork()
        {
            return View();
        }
    }
}