using findmytutor.DataAccess;
using findmytutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace findmytutor.Controllers
{
    public class HomeController : Controller
    {
        private FindMyTutorContext db = new FindMyTutorContext();
        public ActionResult Index( string searching)
        {
            return View(db.tutors.Where(x => x.Name.Contains(searching)|| searching == null).ToList());
        }

      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}