namespace Konu05Metotlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metotlar!");
            Console.WriteLine();
            /*ToplamaYap();
            ToplamaYap2(100, 18);
            Console.WriteLine("Bir sayı giriniz:");
            var sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bir sayı daha giriniz:");
            var sayi2 = Convert.ToInt32(Console.ReadLine());
            ToplamaYap2(sayi1, sayi2);
            Console.WriteLine("ToplamaYap2 metodunun sonucu : " + ToplamaYap2(5,10,15));*/
            Console.WriteLine("Bir metin giriniz:");
            var metin = Console.ReadLine();
            Console.WriteLine("Girilen metindeki küçük harf sayısı : " + KucukHarfSay(metin));
            var sonuc = MailGonder(metin);
            if (sonuc == true)
            {
                Console.WriteLine("Mail gönderildi!");
            }
            else
            {
                Console.WriteLine("Mail gönderilemedi!");
            }
        }
        static void ToplamaYap()
        {
            Console.WriteLine(10 + 8);
        }
        static void ToplamaYap2(int sayi1, int sayi2)
        {
            Console.WriteLine("Sonuç : " + (sayi1 + sayi2));
        }
        static int ToplamaYap2(int sayi1, int sayi2, int sayi3) // metot imzası(isim + parametreler)
        {
            Console.WriteLine();
            return sayi1 + sayi2 + sayi3; // return ile geriye sayıların toplamını döndürdük
        }
        static int KucukHarfSay(string metin)
        {
            int kucukHarfSayisi = 0;
            foreach (char karakter in metin)
            {
                if (char.IsLower(karakter)) // char veri tipinin metotlarından islover metodu kendisine gelen karakter küçük harf mi diye kontrol  eder
                {
                    kucukHarfSayisi++; // gelen karakter küçükse sayıyı 1 artır
                }
            }
            return kucukHarfSayisi;
        }
        static bool MailGonder(string mailAdresi) // dışarıdan bir mail adresi aldık
        {
            if (!string.IsNullOrWhiteSpace(mailAdresi)) // IsNullOrEmpty kendisine verilen mailAdresi değişkeni boş mu diye kontrol eder
            {
                // burada mail göndermek için gerekli kodlar yazılır
                return true; // işlem başarılıysa metodun kullanılacağı yere true değerini gönder
            }
            return false; // yukardaki if bloğu çalışmamışsa geriye false döndür
        }
    }
}