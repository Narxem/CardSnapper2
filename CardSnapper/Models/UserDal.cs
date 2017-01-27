using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSnapper.Models
{
    public class UserDal
    {
        private BddContext db = new BddContext();

        public User authenticate(string username, string password) {
            return db.users.FirstOrDefault(u => u.username == username && u.password == password);
        }

        public User ObtenirUtilisateur(int id) {
            return db.users.FirstOrDefault(u => u.id == id);
        }

        public User ObtenirUtilisateur(string idString) {
            int id;
            if (int.TryParse(idString, out id))
                return ObtenirUtilisateur(id);
            return null;
        }

        public int AjouterUtilisateur(string nom, string motDePasse, string mail) {

            User utilisateur = new User { username = nom, password = motDePasse, mail = mail };

            db.users.Add(utilisateur);

            db.SaveChanges();

            return utilisateur.id;

        }

    }
}