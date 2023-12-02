namespace Konu10StringSinifi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Sınıfı!");
            string degisken;
            char karakter;
            string metin = "String yan yana dizi formatında char yapısıdır.";
            // Ornek();
            StringMetotlari();
        }
        static void Ornek()
        {
            string birMetin = "Ankara başkenttir";
            String birSayi = "123456789";
            System.String birTarih = "28-10-2023";
            string s = "Barış Manço";
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"s[{i}] {s[i]}");
            }
            foreach (var item in s) // s = Barış Manço
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("birMetin veri tipi : " + birMetin.GetType());
            Console.WriteLine("birSayi veri tipi : " + birSayi.GetType());
            Console.WriteLine("birTarih veri tipi : " + birTarih.GetType());
        }
        static void StringMetotlari()
        {
            string metin = "Stringin birçok metodu vardır";
            Console.WriteLine("metinin karakter sayısı : " + metin.Length);
            var klon = metin.Clone();
            Console.WriteLine("Metnin klonu : " + klon);
            metin = "My name is Ali";
            Console.WriteLine("metin : " + metin);
            Console.WriteLine("metin.EndsWith(\"i\")" + metin.EndsWith("i"));
            Console.WriteLine("metin.EndsWith(\"r\")" + metin.EndsWith("r"));
            Console.WriteLine("metin.StartsWith(\"M\")" + metin.StartsWith("M"));
            Console.WriteLine("metin.StartsWith(\"m\")" + metin.StartsWith("m"));
            Console.WriteLine("metin.StartsWith(\"r\")" + metin.StartsWith("r"));
            Console.WriteLine("metin.IndexOf(\"i\")" + metin.IndexOf("i"));
            Console.WriteLine("metin.IndexOf(\"name\")" + metin.IndexOf("name"));
            Console.WriteLine("metin.LastIndexOf(\"i\")" + metin.LastIndexOf("i"));
            Console.WriteLine("metin.Insert - ekleme yapma : " + metin.Insert(0, "Merhaba "));
            Console.WriteLine(metin);
            Console.WriteLine("metin.Substring(2) : " + metin.Substring(2));
            Console.WriteLine("metin.Substring(2, 5) : " + metin.Substring(2, 5));

            Console.WriteLine("metin.ToLower() : " + metin.ToLower());
            Console.WriteLine("metin.ToUpper() : " + metin.ToUpper());

            Console.WriteLine("metin.ToLower().Replace() : " + metin.ToLower().Replace(" ", "-"));
            Console.WriteLine("metin.Remove : " + metin.Remove(2, 5));
            string sehirler =  "İstanbul,Ankara,İzmir";
            Console.WriteLine(sehirler);
            string[] sehirlerArray = sehirler.Split(",");
            Console.WriteLine(sehirlerArray[2]);
            foreach (var item in sehirlerArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}