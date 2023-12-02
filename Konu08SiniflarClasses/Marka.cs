using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konu08SiniflarClasses
{
    internal class Marka // projeye harici class eklemek için projeye sağ tık > add > class menüsünden bir isim verip add diyerek ekliyoruz
    {
        public int Id { get; set; } // bu sınıf içinde uygulamamızda bize lazım olabilecek özellikleri prop tab diyerek tanımlıyoruz
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now; // bir property e başlangıç değeri atayıp eğer bir değer verilmezse onu kullanmasını sağlayabiliriz
        public static string Test = "static tanımlı değişkenleri direk classadi.degiskenadi şeklinde kullanabiliriz, sınıfı new lememiz gerekmez!";
    }
}
