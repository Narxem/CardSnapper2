using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSnapper.Models;

namespace CardSnapper.Controllers {
    public class SignController : Controller {

        private UserDal dal;

        public SignController() : this(new UserDal()) { }

        private SignController(UserDal dalIoc) {
            dal = dalIoc;
        }

        [HttpGet]
        public ActionResult Signin() {
            return View();
        }

        [HttpGet]
        public ActionResult Signup() {
            return View();
        }


        [HttpPost]
        public ActionResult auth() {
            User user = dal.authenticate(Request.Form["username"], Request.Form["password"]);
            if (user == null) {
                return Redirect("/Sign/signin");
            } else {
                //Session["user"] = user;
                return Redirect("/");
            }
        }

        [HttpGet]
        public ActionResult logout() {
            Session["user"] = null;
            Redirect("/");
        }

        [HttpPost]
        public ActionResult signup() {
            dal.AjouterUtilisateur(Request.Form["username"], Request.Form["password"], Request.Form["mail"]);
                return View("signin");
            }
        }
    }
