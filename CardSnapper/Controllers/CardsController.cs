using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSnapper.Controllers
{
    public class CardsController : Controller
    {

        public ActionResult AllCards()
        {
            return View();
        }

        public ActionResult OpenBooster() {
            return View();
        }
    }
}