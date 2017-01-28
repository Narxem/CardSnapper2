using CardSnapper.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CardSnapper.Controllers {
    public class HomeController : Controller {

        private BddContext db = new BddContext();

        public ActionResult Index() {
            if (Session["user"] == null)
                return View("default");
            User user = (User)Session["user"];
            ViewData["name"] = user.username;
            // Total carte dans la bdd
            CardDal cardDal = new CardDal(db);
            List<String> cards = cardDal.getAllStringCards();
            ViewData["nombreCartes"] = cards.Count;
            //Envoyer nombre carte de l'utilisateur 
            ViewData["nombreCartesUser"] = user.collection.Count;
            return View();
        }

        public ActionResult allCards() {
            return View("allCards");
        }

        public ActionResult maCollection() {
            return View("maCollection");
        }

        public ActionResult openBooster() {
            return View("openBooster");
        }

        public ActionResult signin() {
            return View("signin");
        }

        public ActionResult signup() {
            return View("signup");
        }

    }
}