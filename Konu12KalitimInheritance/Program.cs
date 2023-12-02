namespace Konu12KalitimInheritance
{
    class Arac
    {
        public string AracTuru;
        public void AracKornasi()
        {
            Console.WriteLine("Kornaya basıldı!");
        }
    }
    class Otomobil : Arac // otomobil sınıfı araç sınıfının içindekileri miras aldı
    {
        public string Marka { get; set; }
        public string Model { get; set; }
    }
    class Tren : Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kalıtım, Inheritance!");
            Arac arac = new Arac();
            arac.AracTuru = "Otomobil";
            Console.WriteLine("Araç Türü : " + arac.AracTuru);
            Otomobil otomobil = new();
            otomobil.AracKornasi(); // AracKornasi metodu otomobil sınıfında olmadığı halde miras alma yöntemiyle çalıştırabiliyoruz.
            otomobil.Marka = "TOGG";
            otomobil.Model = "T10X";
            Console.WriteLine("Araç marka model : " + otomobil.Marka + " " + otomobil.Model);
            Kategori kategori = new Kategori();
            kategori.Name = "Test"; // name özelliği ortak özellikler classından geliyor
            kategori.YanMenu = true;
            Console.WriteLine("Kategori Adı : " + kategori.Name);
            Console.WriteLine("Kategori yan menüde gösterilsin mi? ");
            Console.WriteLine(kategori.YanMenu);

            Urun urun = new()
            {
                Name = "Bilgisayar",
                Fiyat = 9999,
                Description = "İş bilgisayarı"
            };
            Console.WriteLine(urun.Name);
            kategori.Ekle();
            urun.Ekle();

            Cizici[] birCizici = new Cizici[3];
            birCizici[0] = new DogruCiz();
            birCizici[1] = new DaireCiz();
            birCizici[2] = new Cizici();

            foreach (var item in birCizici)
            {
                item.Ciz();
            }
        }
        // Polimorpizm - çok biçimlilik
        public class Cizici
        {
            public virtual void Ciz() // bu metotta virtual keyword ünün kullandık ki bu metodu ezebilelim
            {
                Console.WriteLine("Cizici metodu çalıştı");
            }
        }
        public class DogruCiz : Cizici // Cizici sınıfından miras aldık
        {
            public override void Ciz() // burada normalde Cizici sınıfında olan ciz metodunu ele alıp farklı bir iş yapmasını sağlıyoruz override yöntemiyle
            {
                Console.WriteLine("DogruCiz metodu çalıştı");
            }
        }
        public class DaireCiz : Cizici
        {
            public override void Ciz()
            {
                Console.WriteLine("DaireCiz metodu çalıştı");
            }
        }
    }
}