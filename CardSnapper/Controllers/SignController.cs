using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSnapper.Models;

namespace CardSnapper.Controllers {
    public class SignController : Controller {

        private BddContext db = new BddContext();


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
            UserDal dal = new UserDal(db);
            User user = dal.authenticate(Request.Form["username"], Request.Form["password"]);
            if (user == null) {
                return Redirect("/Sign/signin");
            } else {
                Session["user"] = user;
                return Redirect("/");
            }
        }

        [HttpGet]
        public ActionResult logout() {
            Session["user"] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult signup() {
            UserDal dal = new UserDal(db);
            dal.AjouterUtilisateur(Request.Form["username"], Request.Form["password"], Request.Form["mail"]);
                return View("signin");
            }
        }
    }
