namespace Konu15AbstractClaslar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract, Classlar!");
            Database sqlServer = new SqlServer(); // new Database(); // abstract sınıftan bu  şekilde new diyerek nesne üretemeyiz! Ancak kalıtım alan class tan nesne oluşturabiliriz
            sqlServer.Delete();
            sqlServer.Add();
            Database mysql = new MySql();
            mysql.Add();
            mysql.Update();
        }
    }
    abstract class Database
    {
        // abstract sınıflarda aşağıdaki gibi metot tanımlayabiliriz
        public void Add()
        {
            Console.WriteLine("Ekleme metdou çalıştı.");
        }
        // abstract sınıflarda aşağıdaki gibi metot imzası tanımlayabiliriz
        public abstract void Delete();
        public abstract void Update();
        public abstract void Get();
    }
    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("SqlServer dan kayıt silindi");
        }

        public override void Get()
        {
            Console.WriteLine("SqlServer dan kayıt getirildi");
        }

        public override void Update()
        {
            Console.WriteLine("SqlServer da kayıt güncellendi");
        }
    }
    class MySql : Database
    {
        public override void Delete()
        {
            Console.WriteLine("MySql dan kayıt silindi");
        }

        public override void Get()
        {
            Console.WriteLine("MySql dan kayıt getirildi");
        }

        public override void Update()
        {
            Console.WriteLine("MySql dan kayıt güncellendi");
        }
    }

}