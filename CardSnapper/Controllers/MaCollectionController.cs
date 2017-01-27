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
        //[Authorize] -> Gérer les rôles -> https://msdn.microsoft.com/fr-fr/library/5k850zwb(v=vs.100).aspx
        public ActionResult Index()
        {
            return View();
        }

    }
}
