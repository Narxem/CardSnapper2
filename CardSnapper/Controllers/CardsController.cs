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
            return View();
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
                        return View();
                    }
        // POST: Carte/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,rarity,imageURL")] Card card) {
                        if (ModelState.IsValid) {
                db.cards.Add(card);
                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
            
                        return View(card);
                    }
        // GET: Carte/Edit/5
        public ActionResult Edit(int? id) {
                        if (id == null) {
                                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                            }
            Card card = db.cards.Find(id);
                        if (card == null) {
                                return HttpNotFound();
                            }
                        return View(card);
                    }
        // POST: Carte/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,rarity,imageURL")] Card card) {
                        if (ModelState.IsValid) {
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                        return View(card);
                    }

        // GET: Carte/Delete/5
        public ActionResult Delete(int? id) {
                        if (id == null) {
                                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                            }
            Card card = db.cards.Find(id);
                        if (card == null) {
                                return HttpNotFound();
                            }
                        return View(card);
                    }
        // POST: Carte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Card card = db.cards.Find(id);
            db.cards.Remove(card);
            db.SaveChanges();
                        return RedirectToAction("Index");
                    }

        protected override void Dispose(bool disposing) {
                        if (disposing) {
                db.Dispose();
                            }
            base.Dispose(disposing);
                    }
    }
}