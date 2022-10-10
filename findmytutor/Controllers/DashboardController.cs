using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace findmytutor.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            string current = System.Web.HttpContext.Current.User.Identity.Name;
            return View();
        }
    }
}