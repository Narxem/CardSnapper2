using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CardSnapper.Models {
    public class BddContext : DbContext {
        public DbSet<User> users { get; set; }
        public DbSet<Card> cards { get; set; }
    }
}