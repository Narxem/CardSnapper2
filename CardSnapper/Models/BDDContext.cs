using System.Data.Entity;


namespace CardSnapper.Models {
    public class BddContext : DbContext {
        public DbSet<User> users { get; set; }
        public DbSet<Card> cards { get; set; }
    }
}