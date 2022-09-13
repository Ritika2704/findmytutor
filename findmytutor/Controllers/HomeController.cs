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
        public ActionResult Index(string searching)
        {
            List<TutorSearchModel> tutorSearch = new List<TutorSearchModel>();

            try
            {
                if (!string.IsNullOrEmpty(searching))
                {
                    tutorSearch = db.tutors.Where(x => x.Name.Contains(searching)).Select(x => new TutorSearchModel
                    {
                        Name = x.Name,
                        State = "Haryana",
                        City = "Sonepat",
                        EmailAddress = x.EmailAddress,
                        PhoneNumber = x.PhoneNumber,
                        Address = x.Address
                    }
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                //Logging here
            }

            return View(tutorSearch);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}