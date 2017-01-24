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
                return View("Error");
            ViewData["nom"] = id;
            return View();
        }
    }
}