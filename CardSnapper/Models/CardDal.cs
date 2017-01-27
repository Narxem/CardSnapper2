using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSnapper.Models {
    public class CardDal {
        private BddContext db = new BddContext();
        private Random rand = new Random();

        public List<Card> getAllCards() {
            return db.cards.ToList();
        }

        public List<String> getAllStringCards() {
            List<Card> liste = getAllCards();
            List<String> listeTitre = null;
            foreach(Card carte in liste) {
                String image = carte.imageURL;
                listeTitre.Add(image);
            }
            return listeTitre;
        }

        public Card getRandomCard() {
            List<Card> cards = getAllCards();
            return cards[rand.Next(0, cards.Count)];
        }
    }
}