using findmytutor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using findmytutor.Models;

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
            return View(register);
        }

        public ActionResult GetStates()
        {
            return Json(db.States.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCities()
        {
            return Json(db.cities.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}