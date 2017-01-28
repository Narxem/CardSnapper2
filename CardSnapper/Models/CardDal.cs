using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSnapper.Models {
    public class CardDal {

        private BddContext db;
        private Random rand = new Random();

        public CardDal(BddContext context) {
            db = context;
        }

        public List<Card> getAllCards() {
            return db.cards.ToList();
        }

        public List<String> getAllStringCards() {
            List<Card> liste = getAllCards();
            List<String> listeTitre = new List<String>();
            foreach(Card carte in liste) {              
                String image = carte.imageURL;
                if(image != null) { 
                    listeTitre.Add(image);
                }
            }
            return listeTitre;
        }

        public List<String> getUserCardString(User id) {
            List<Card> liste = id.collection.ToList<Card>();
            List<String> listeTitre = new List<String>();
            foreach (Card carte in liste) {
                String image = carte.imageURL;
                if (image != null) {
                    listeTitre.Add(image);
                }
            }
            return listeTitre;
        }

        public Card getRandomCard() {
            List<Card> cards = getAllCards();
            return cards[rand.Next(0, cards.Count)];
        }
    }
}