using findmytutor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using findmytutor.Models;
using findmytutor.Models.Entities;

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
            RegisterModel register = new RegisterModel();
            //Now we will first get the data for State
            List<SelectListItem> contentData = new List<SelectListItem>();
            contentData.Add(new SelectListItem
            {
                Text = "State 1",
                Value = "1",
            });

            contentData.Add(new SelectListItem
            {
                Text = "State 2",
                Value = "2",
            });

            //List<States> myStates = db.States.ToList();

            //Convert above list to SelectList
            //Send the list to Register View
            //Give default option of --Select State-- with value of 0
            //Now using AJAX or Jquery get the city based on the state

            ViewBag.States = contentData;
            return View(register);
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