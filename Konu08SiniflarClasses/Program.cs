using ClassLibrary1;

namespace Konu08SiniflarClasses
{
    class Ev
    {
        internal string sokakAdi; // internal = erişim belirteci
        internal int kapiNo;
    }
    /*
        Erişim belirteçleri:
        Sınıflar ve sınıf öğelerine erişimi kısıtlamak için kullanılır.
    Public    : Erişim kısıtı yoktur her yerden erişilebilir
    Protected : Ait olduğu sınıftan ve o sınıftan türetilen sınıflardan erişilebilir
    internal  : Etkin projeye ait sınıflardan erişilebilir
    private   : yalnız bulunduğu sınıftan erişilebilir

    1 öğe sadece 1 erişim belirteci alabilir!
    namespace erişim belirteci almaz public tir
     */
    public class deneme
    {
        public string urunAdi = "klavye";
        protected class test
        {
            string urunAdi; // erişim belirteci vermezsek varsayılan private olur
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sınıflar, Classes!");
            Ev ev = new Ev(); // yukardaki ev sınıfından ev isminde bir somut nesne oluşturduk
            ev.sokakAdi = "papatya sokak"; // erişim belirteci tanımlayıp ev sınıfındaki değişkenlere veri atayabildik
            ev.kapiNo = 18;
            Console.WriteLine("Sokak adı : " + ev.sokakAdi);
            Console.WriteLine("Kapı numarası : " + ev.kapiNo);

            Console.WriteLine();

            Ev yazlik = new Ev();
            yazlik.sokakAdi = "Deniz sk.";
            yazlik.kapiNo = 1;

            Console.WriteLine(yazlik.sokakAdi);
            Console.WriteLine(yazlik.kapiNo);

            Console.WriteLine();

            Ev koyEvi = new() // Ev sınıfından bu şekilde de nesne oluşturabiliriz
            {
                kapiNo = 1, // bu tanımlamada değişkenler arası virgül ile ayrılır
                sokakAdi = "Yeşil bahçe sokak"
            };
            Console.WriteLine("koyEvi \n Bilgileri : ");
            Console.WriteLine(koyEvi.sokakAdi);
            Console.WriteLine(koyEvi.kapiNo);

            Kategori kategori = new Kategori();
            kategori.Adi = "Elektronik";

            Console.WriteLine(kategori.Adi);

            Kullanici kullanici = new Kullanici()
            {
                Adi = "Ali",
                KullaniciAdi = "ali",
                Sifre = "Al123"
            };
            Kullanici kullanici1 = new()
            {
                Adi = "Sude",
                KullaniciAdi = "sd34",
                Sifre = "su321"
            };
            Console.WriteLine($"Kullanıcı Bilgileri : \n{kullanici1.Adi}\n{kullanici1.KullaniciAdi}");

            Araba araba = new()
            {
                Id = 1,
                KasaTipi = "Sedan",
                Marka = "Mercedes",
                Model = "Maybach",
                Renk = "Siyah",
                VitesTipi = "Otomatik"
            };
            Console.WriteLine($"{kullanici1.Adi} kullanıcısının Araç Bilgileri :\n{araba.Marka} {araba.Model}");

            Kategori kategori1 = new()
            {
                Id = 1,
                Adi = "Elektronik"
            };
            Kategori kategori2 = new()
            {
                Id = 2,
                Adi = "Telefon"
            };
            Console.WriteLine("Kategori Adı : " + kategori1.Adi);

            Console.WriteLine();
            SiniftaMetotKullanimi siniftaMetotKullanimi = new();

            Console.WriteLine("siniftaMetotKullanimi : " + siniftaMetotKullanimi.ToplamaYap(10, 8));
            
            Console.WriteLine("LoginKontrol : " + siniftaMetotKullanimi.LoginKontrol("admin", "1234"));

            Console.WriteLine(Marka.Test); // static değişken kullanımı sınıfadı.özellikadı

            Product product = new();
            product.Id = 1;
            product.Name = "Test";
            product.Price = 10;
        }
    }
    class Kullanici
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
    class Araba
    {
        internal int Id;
        internal string Marka;
        internal string Model;
        internal string KasaTipi;
        internal string YakitTipi;
        internal string VitesTipi;
        internal string Renk;
    }
}