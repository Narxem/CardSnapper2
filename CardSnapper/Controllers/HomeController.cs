using CardSnapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSnapper.Controllers {
    public class HomeController : Controller {


        public ActionResult Index() { 
            if (Session["user"] == null)
                return View("default");
            User user = (User) Session["user"];
            ViewData["name"] = user.username;
            return View();
        }

        public ActionResult allCards()
        {
            return View("allCards");
        }

        public ActionResult maCollection()
        {
            return View("maCollection");
        }

        public ActionResult openBooster()
        {
            return View("openBooster");
        }

        public ActionResult signin()
        {
            return View("signin");
        }

        public ActionResult signup()
        {
            return View("signup");
        }

    }
}