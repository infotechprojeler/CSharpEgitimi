namespace Konu13Kapsulleme
{
    // Metot kullanarak kapsülleme
    public class Bolum
    {
        private string BolumAdi; // kapsülleme yapacağımız değişken
        // accesor - getter
        public string GetBolumAdi()
        {
            return BolumAdi;
        }
        // mutator - setter
        public void SetBolumAdi(string a)
        {
            if (a == "Yazılım")
            {
                BolumAdi = a;
            }
            else
            {
                Console.WriteLine(a + " Bölüm eğitimi kurumumuzda verilmemektedir");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kapsülleme, Encaptulation!");
            Console.WriteLine("Nesne yönelimli programlamada kapsülleme eylemi verinin veya metodun başka yerden görünmeyecek biçimde üstünün sınıf içinde örtülmesidir.");
            Bolum bolum = new Bolum();
            Console.WriteLine("Seçtiğiniz Bölüm Adı:");
            var secilen = Console.ReadLine();
            bolum.SetBolumAdi(secilen);
            Console.WriteLine(bolum.GetBolumAdi() + " bölümüne kaydınız yapılmıştır"); // dışarıdan yollanan veriyi çağırıyoruz

            Console.WriteLine();
            Fakulte fakulte = new Fakulte();
            fakulte.Bolum = secilen;
            Console.WriteLine(fakulte.Bolum + " bölümüne kaydınız yapılmıştır");
        }
    }
    // Property kullanarak kapsülleme
    class Fakulte
    {
        private string bolum;
        public string Bolum
        {
            get{  return bolum; }
            set
            {
                if (value == "Yazılım")
                {
                    bolum = value;
                }
                else
                {
                    Console.WriteLine("Kurumumuzda " + value + " eğitimi verilmemektedir");
                    return;
                }
            }
        }
    }
}