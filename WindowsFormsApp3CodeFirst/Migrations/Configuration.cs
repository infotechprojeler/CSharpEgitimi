namespace WindowsFormsApp3CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WindowsFormsApp3CodeFirst.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WindowsFormsApp3CodeFirst.DatabaseContext";
        }

        protected override void Seed(WindowsFormsApp3CodeFirst.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.
            // Bu metot veritabanı kurulduktan sonra çalışır ve uygulama çalıştıktan sonra test kayıtları veya standart kullanıcı oluşturma gibi işlemleri yapmamızı sağlar.
        }
    }
}
