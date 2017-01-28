using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSnapper.Models;

namespace CardSnapper.Controllers
{
    public class MaCollectionController : Controller
    {
        private CardDal cardDal = new CardDal();
        // GET: MaCollection
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            List<String> liste = cardDal.getUserCardString(user);
            ViewData["image"] = liste;
            return View();
        }

    }
}
