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
                    tutorSearch = db.tutors.Where(x => x.Name.Contains(searching) || x.Address.Contains(searching) || x.PhoneNumber.Contains(searching)).Select(x => new TutorSearchModel
                    {
                        Name = x.Name,
                        State = db.States.Where(y=>y.state_id==x.State).Select(y=>y.statename).FirstOrDefault(),
                        City = db.cities.Where(y=>y.city_id == x.City).Select(y => y.city_name).FirstOrDefault(),
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