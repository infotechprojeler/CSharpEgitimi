namespace Konu01Degiskenler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Değişkenler!");
            // Değişken tanımlama - tam sayılar
            byte plakakodu = 34;
            short kisa = 123;
            int tamsayi = 1800;
            long uzunsayi = 123456;

            // Kesirli sayılar
            float kesirliSayi = 4.5f;
            double kesirlidouble = 4.5;
            decimal urunFiyati = 5500;

            // Karakter
            char karakter = 'c'; // klavyedeki tüm karakterleri taşıyabilir

            // string veri tipi
            string metin = "klavyedeki tüm karakterleri yan yana yazılmış olarak taşıyabilir";

            // boolean veri tipi
            bool islemSonucu = false; // işlem başarılı mı başarısız mı 2 değer alabilir true-false

            Console.WriteLine("Metin yazısı : " + metin);
            Console.WriteLine("islemSonucu {0} ikinci parametre : {1}", islemSonucu, karakter);
            metin = "yeni metin";
            Console.WriteLine($"islemSonucu {islemSonucu} Metin yazısı : {metin}");

            // C# ta Sabit Tanımlama
            const int kdvMiktari = 18;
            // kdvMiktari = 20; sabitlerin değeri sonradan değiştirilemez!
            Console.WriteLine(kdvMiktari);
        }
    }
}
