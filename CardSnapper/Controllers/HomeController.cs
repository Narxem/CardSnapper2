using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSnapper.Controllers
{
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index(string id) { 
            if (string.IsNullOrEmpty(id))
                //Plutot retourner Login non?
                return View("signin");
            ViewData["nom"] = id;
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