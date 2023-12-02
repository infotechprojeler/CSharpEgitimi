using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konu08SiniflarClasses
{
    internal class Urun
    {
        // class değişkenleri
        internal int Id;
        internal string Adi;
        internal decimal Fiyati;
        // class içinde property kullanımı
        public string UrunAciklamasi { get; set; }
        public int KategoriId { get; set; }
        public string Marka { get; set; }
        public bool Durum { get; set;}
    }
    partial class UrunOzellik
    {
        internal int Id;
        internal string Adi;
        internal string Renk;
    }
}
