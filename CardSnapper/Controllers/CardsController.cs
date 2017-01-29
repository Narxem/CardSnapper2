using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CardSnapper.Models;

namespace CardSnapper.Controllers
{
    public class CardsController : Controller
    {
        private BddContext db = new BddContext();
        

        public ActionResult AllCards()
        {
            CardDal cardDal = new CardDal(db);
            List <String> cards = cardDal.getAllStringCards();
            ViewData["image"] = cards;
            return View();
        }

        public ActionResult OpenBooster() {
            
            return View();
        }

        public ActionResult ouvrirBooster() {

            CardDal cardDal = new CardDal(db);
            UserDal userDal = new UserDal(db);
            Card card = cardDal.getRandomCard();
            User user = (User)Session["user"];
            User userDb = userDal.ObtenirUtilisateur(user.id);
            user.collection.Add(card);

            userDb.collection.Add(card);
            card.users.Add(userDb);

            db.Entry(userDb).State = EntityState.Modified;
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
            ViewData["image"] = card.imageURL;
            return View("OpenBooster");

        }
        // GET: Carte
        public ActionResult Index() {
            return View(db.cards.ToList());
        }

        // GET: Carte/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.cards.Find(id);
            if (card == null) {
                return HttpNotFound();
            }
            return View(card);
        }

        // GET: Carte/Create
        public ActionResult Create() {
            if(Session["user"] != null && ((User)Session["user"]).isAdmin)
                return View();
            return View("Error");
        }

        // POST: Carte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,rarity,imageURL")] Card card) {
            if (Session["user"] != null && ((User) Session["user"]).isAdmin) {
                db.cards.Add(card);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Error");
        }
   
        // GET: Carte/Edit/5
        public ActionResult Edit(int? id) {
            if (Session["user"] != null && ((User)Session["user"]).isAdmin) {
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Card card = db.cards.Find(id);
                if (card == null) {
                    return HttpNotFound();
                }
                return View(card);
            }
            return View("Error");
        }
        
        // POST: Carte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,rarity,imageURL")] Card card) {
            if (Session["user"] != null && ((User)Session["user"]).isAdmin) {
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        // GET: Carte/Delete/5
        public ActionResult Delete(int? id) {
            if (Session["user"] != null && ((User)Session["user"]).isAdmin) {
                if (id == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Card card = db.cards.Find(id);
                if (card == null) {
                    return HttpNotFound();
                }
                return View(card);
            }
            return View("Error");
        }
        // POST: Carte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            if (Session["user"] != null && ((User)Session["user"]).isAdmin) {
                Card card = db.cards.Find(id);
                db.cards.Remove(card);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}