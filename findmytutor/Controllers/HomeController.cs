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
        public ActionResult Index(string searching, string stateid, string cityid)
        {
            List<FilterModel> filterSearch = new List<FilterModel>();
            List<Models.Entities.States> statelist = db.States.OrderBy(x => x.statename).ToList();
            ViewBag.StatesTb1 = new SelectList(statelist, "state_id", "statename");

            List<Models.Entities.cities> citylist = db.cities.OrderBy(x => x.city_name).ToList();
            ViewBag.citiesTb1 = new SelectList(citylist, "city_Id", "city_name", "state_id");

            List<TutorSearchModel> tutorSearch = new List<TutorSearchModel>();

            try
            {
                if(!string.IsNullOrEmpty(stateid) && !string.IsNullOrEmpty(cityid))
                {
                    int cityidInt = Convert.ToInt32(cityid);
                    int stateidInt = Convert.ToInt32(stateid);

                    tutorSearch = db.tutors.Where(x => x.City == cityidInt && x.State == stateidInt).Select(x => new TutorSearchModel
                    {
                        Name = x.Name,
                        State = db.States.Where(y => y.state_id==x.State).Select(y => y.statename).FirstOrDefault(),
                        City = db.cities.Where(y => y.city_id == x.City).Select(y => y.city_name).FirstOrDefault(),
                        EmailAddress = x.EmailAddress,
                        PhoneNumber = x.PhoneNumber,
                        Address = x.Address
                    }
                    ).ToList();
                }
                else if(!string.IsNullOrEmpty(stateid))
                {
                    int stateidInt = Convert.ToInt32(stateid);
                    tutorSearch = db.tutors.Where(x => x.State == stateidInt).Select(x => new TutorSearchModel
                    {
                        Name = x.Name,
                        State = db.States.Where(y => y.state_id==x.State).Select(y => y.statename).FirstOrDefault(),
                        City = db.cities.Where(y => y.city_id == x.City).Select(y => y.city_name).FirstOrDefault(),
                        EmailAddress = x.EmailAddress,
                        PhoneNumber = x.PhoneNumber,
                        Address = x.Address
                    }
                    ).ToList();
                }
                else if(!string.IsNullOrEmpty(cityid))
                {
                    int cityidInt = Convert.ToInt32(cityid);
                    tutorSearch = db.tutors.Where(x => x.City == cityidInt).Select(x => new TutorSearchModel
                    {
                        Name = x.Name,
                        State = db.States.Where(y => y.state_id==x.State).Select(y => y.statename).FirstOrDefault(),
                        City = db.cities.Where(y => y.city_id == x.City).Select(y => y.city_name).FirstOrDefault(),
                        EmailAddress = x.EmailAddress,
                        PhoneNumber = x.PhoneNumber,
                        Address = x.Address
                    }
                    ).ToList();
                }
                else
                {
                    if (!string.IsNullOrEmpty(searching))
                    {
                        tutorSearch = db.tutors.Where(x => x.Name.Contains(searching) || x.Address.Contains(searching) || x.PhoneNumber.Contains(searching)).Select(x => new TutorSearchModel
                        {
                            Name = x.Name,
                            State = db.States.Where(y => y.state_id==x.State).Select(y => y.statename).FirstOrDefault(),
                            City = db.cities.Where(y => y.city_id == x.City).Select(y => y.city_name).FirstOrDefault(),
                            EmailAddress = x.EmailAddress,
                            PhoneNumber = x.PhoneNumber,
                            Address = x.Address
                        }
                        ).ToList();
                    }
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