using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSnapper.Controllers
{
    public class MaCollectionController : Controller
    {
        // GET: MaCollection
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
