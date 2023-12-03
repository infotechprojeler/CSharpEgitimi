using ClassLibrary2;
using System.Data.Entity; // entity framework

namespace WindowsFormsApp3CodeFirst
{
    internal class DatabaseContext : DbContext // app.config dosyasına DatabaseContext ismiyle bir connection string eklersek ef veritabanını otomatik olarak bulur
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
