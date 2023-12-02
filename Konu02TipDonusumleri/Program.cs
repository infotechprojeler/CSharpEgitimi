namespace Konu02TipDonusumleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tip Dönüşümleri!");
            Console.WriteLine("Implicit Casting - Otomatik Tip Dönüşümü");
            int sayi = 18;
            double kesirliSayi = sayi;
            Console.WriteLine(sayi);

            Console.WriteLine("Explicit Casting - Manuel Dönüştürme");
            double kesirliSayi2 = 18;
            int tamSayi = (int)kesirliSayi2; // parantez içerisinde gelecek veri tipini belirtiyoruz

            Console.WriteLine(tamSayi);

            var strparsayi = "123456"; // var anahtar kelimesi ile değişken oluşturabiliriz, bu durumda atanan veri tipine göre değişken tipi otomatik belirlenir.
            var tmsayi = 123;

            var kesirli = 123.58;

            Console.WriteLine("strparsayi veri tipi : " + strparsayi.GetType());

            Console.WriteLine("int.Parse : " + int.Parse(strparsayi));
            Console.WriteLine("double.Parse : " + double.Parse(strparsayi));
            Console.WriteLine("decimal.Parse : " + decimal.Parse(strparsayi));

            Console.WriteLine(Convert.ToInt32(strparsayi));
            Console.WriteLine(Convert.ToDouble(strparsayi));
            Console.WriteLine(Convert.ToDecimal(strparsayi));
        }
    }
}