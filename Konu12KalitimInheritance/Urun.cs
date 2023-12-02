namespace Konu12KalitimInheritance
{
    internal class Urun : OrtakOzellikler
    {
        public string Resim { get; set; }
        public decimal Fiyat { get; set; }
        public int KDV { get; set; }
        public double Iskonto { get; set; }
        public string TeknikOzellikler { get; set; }
        public bool AnasayfadaGoster { get; set; }
    }
}
