using System.Data.Entity; // entity framework kütüphanesi

namespace WebApplicationMVCEgitim.Models
{
    public class UyeContext : DbContext // entity framework kütüphanesi içindeki ana db context
    {
        public DbSet<Uye> Uyeler { get; set; }
    }
}