namespace Konu17HataYonetimi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hata Yönetimi!");
            Console.WriteLine("Bir Sayı Giriniz");
            var sayi = Console.ReadLine();
            try
            {
                // hata oluştuğunda uygulamanın çökmesini engellemek için kodlarımızı try bloğunda çalıştırırız!
                // Eğer kodlar çalıştığında hata oluşursa uygulama çökmez ve catch bloğundaki işlemi yapar
                KdvHesapla(double.Parse(sayi)); // metodu buraya alarak uygulamayı hatadan koruduk
            }
            catch (Exception hata) // hatayı yakalamak için Exception sınıfına bir isim verdik
            {
                Console.WriteLine("Geçersiz Değer Girdiniz!\nLütfen sadece sayısal değer giriniz.."); // catch bloğunda kullanıcıya anlayacağı şekilde bir uyarı gösterilir.
                //throw; // throw yine hata fırlatır
                Console.WriteLine(hata); // hatayı lokalde görüp incelemek için ekrana bastırabiliriz
                Console.WriteLine();
                Console.WriteLine(hata.Message); // hatanın mesajını gör
                // oluşan hatalar bu blokta loglanır
            }
            finally
            {
                Console.WriteLine("try cach bloğu çalıştıktan sonra bu alan çalışır");
            }

        }
        static void KdvHesapla(double fiyat)
        {
            Console.WriteLine("Fiyat : " + fiyat);
            Console.WriteLine("Kdv : " + (fiyat * 0.20));
            Console.WriteLine("Kdv Dahil Toplam Tutar : " + (fiyat + (fiyat * 0.20)));
        }
    }
}