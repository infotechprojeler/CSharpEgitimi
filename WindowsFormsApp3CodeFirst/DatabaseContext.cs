using ClassLibrary2;
using System.Data.Entity; // entity framework

namespace WindowsFormsApp3CodeFirst
{
    internal class DatabaseContext : DbContext // app.config dosyasına DatabaseContext ismiyle bir connection string eklersek ef veritabanını otomatik olarak bulur
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        // Migrations ı aktif etmek için önce en üst menüden Tools > Nuget package manager > Package manager console a tıklayarak aşağıda komut yazma bölümünü aktif ediyoruz
        // Aşağıya Package manager console geldikten sonra tıklayarak açıyoruz ve açılan bölümden Default project alanından solution içerisinde hangi projeye komut yazmak istersek onu combobox dan seçiyoruz!! 
        // PM yazan alana enable-migrations yazıp enter a basıyoruz
        // işler yolunda gittiyse proje içerisine migrations klasörü ve içine gerekli classlar oluşacak
        // sonraki adımda veritabanını oluşturmak veya güncellemek için yine Package manager console a update-database komutunu yazıp enter a basıyoruz
        // bir sorun yoksa running seed metot yazısı gelir ve değişiklikler veritabanına yansıtılır

        // bundan sonra yapılacak değişiklikler için ise add-migration migrationAdi yazıp enter ve sonrasında tekrar update-database diyerek ilerliyoruz.
    }
}
