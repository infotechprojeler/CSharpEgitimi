using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konu08SiniflarClasses
{
    internal class SiniftaMetotKullanimi
    {
        string kurucuMetot;
        // ctor : kurucu metot oluşturmanın kısayolu
        public SiniftaMetotKullanimi()
        {
            kurucuMetot = "Kurucu metotlar sınıftan alınan her nesne örneğinde öncelikli çalışan metotlardır";
            Console.WriteLine(kurucuMetot);
            Console.WriteLine();
        }
        public bool LoginKontrol(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "123")
            {
                return true;
            }
            return false;
        }
        public int ToplamaYap(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        ~SiniftaMetotKullanimi() // tilda işareti : altgr + ü + boşluk ~
        {
            // yıkıcı metot, class ın örneğinin bellekten atılması için kullanılabilir.
            // .net içerisinde gc: garbage collector yapısı vardır, bu yapı bellekte kalan ve kullanılmayan nesneleri belirli aralıklarla temizler.
        }
    }
}
