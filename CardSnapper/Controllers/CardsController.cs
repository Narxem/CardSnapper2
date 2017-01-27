using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSnapper.Models;

namespace CardSnapper.Controllers
{
    public class CardsController : Controller
    {
        private CardDal cardDal;

        public ActionResult AllCards()
        {
            List <String> cards = cardDal.getAllStringCards();
            ViewData["image"] = cards;
            return View();
        }

        public ActionResult OpenBooster() {
            return View();
        }
    }
}