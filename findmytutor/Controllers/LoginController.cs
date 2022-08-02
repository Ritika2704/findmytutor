using findmytutor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace findmytutor.Controllers
{
    public class LoginController : Controller
    {
        private FindMyTutorContext db = new FindMyTutorContext();
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult GetStates()
        {
            return Json(db.States.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}