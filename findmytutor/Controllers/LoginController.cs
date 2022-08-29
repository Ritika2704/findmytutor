using findmytutor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using findmytutor.Models;
using findmytutor.Models.Entities;
using Scrypt;


namespace findmytutor.Controllers
{
    public class LoginController : Controller
    {
        private FindMyTutorContext db = new FindMyTutorContext();
      
        public ActionResult LoginPage()
        {
            LoginModel login = new LoginModel();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuthenticateUser(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Authenticate user against DB
                    string currentEmail = login.Email;
                    string currentPassword = login.Password;

                    //bool result = AuthenticateUser(currentEmail, currentPassword);
                    //bool result = false;
                    //if true, then redirect to next page
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Model State");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View("LoginPage", login);
        }

        public ActionResult RegisterPage()
        {
            List<States> statelist = db.States.OrderBy(x=>x.statename).ToList();
            ViewBag.StatesTb1 = new SelectList(statelist, "state_id" , "statename");

            List<cities> citylist = db.cities.OrderBy(x=>x.city_name).ToList();
            ViewBag.citiesTb1 = new SelectList(citylist, "city_Id", "city_name", "state_id");
           
            //RegisterModel register = new RegisterModel();
            //Now we will first get the data for State
            //List<SelectListItem> contentData = new List<SelectListItem>();
            //contentData.Add(new SelectListItem
            //{
                //Text = "State 1",
                //Value = "1",
            //});

            //contentData.Add(new SelectListItem
            //{
                //Text = "State 2",
                //Value = "2",
            //});

            //List<States> myStates = db.States.ToList();

            //Convert above list to SelectList
            //Send the list to Register View
            //Give default option of --Select State-- with value of 0
            //Now using AJAX or Jquery get the city based on the state

         //   ViewBag.States = contentData;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(RegisterModel register)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            List<States> statelist = db.States.OrderBy(x => x.statename).ToList();
            ViewBag.StatesTb1 = new SelectList(statelist, "state_id", "statename");

            List<cities> citylist = db.cities.OrderBy(x => x.city_name).ToList();
            ViewBag.citiesTb1 = new SelectList(citylist, "city_Id", "city_name", "state_id");
            Tutor tut = new Tutor();
  
            tut.Name = register.Name;
            tut.EmailAddress = register.EmailAddress;
            tut.PhoneNumber = register.MobileNumber;
            tut.State = register.State;
            tut.City = register.City;
            tut.Address = register.Address;
            tut.Password = encoder.Encode(register.Password);

            bool insertResult = false;
            //Insert in DB and get a result
            FindMyTutorContext findMyTutorContext = new FindMyTutorContext();
            using (FindMyTutorContext context = findMyTutorContext)
            {
                context.tutors.Add(tut);
                int result= context.SaveChanges();
                if(result > 0)
                {
                    insertResult=true;
                }
            }
            if(insertResult)
            {
                register.OutputMessage="Succesfully registered";
            }
            else
            {
                register.OutputMessage="There was a problem in registering. Please contact admin";
            }
            return View("RegisterPage", register);

        }
        public ActionResult GetStates()
        {
            return Json(db.States.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCities(string state_id)
        {
            int convertedstate_id = 0;
            if (!string.IsNullOrEmpty(state_id))
            {
                convertedstate_id = Convert.ToInt32(state_id);
            }

            return Json(db.cities.Where(x=>x.state_id == convertedstate_id).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}