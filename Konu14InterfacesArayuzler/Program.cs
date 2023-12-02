namespace Konu14InterfacesArayuzler
{
    interface OrnekArayuz
    {
        // örnek arayz tanımlaması
        public int Id { get; set; }
    }
    interface ISinifGereksinimleri
    {
        // bu arayüzü kullanacak class lar aşağıdaki özellikleri içermek zorundadır!
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    interface IVeritabaniIslemleri
    {
        // bu arayüzü kullanacak class lar aşağıdaki metotları içermek zorundadır!
        void Add();
        void Update();
        void Delete();
        void GetAll();
    }
    class Urun : ISinifGereksinimleri, IVeritabaniIslemleri
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public void Add()
        {
            Console.WriteLine("Ürün eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("Ürün silindi");
        }

        public void GetAll()
        {
            Console.WriteLine("Ürünler listelendi");
        }

        public void Update()
        {
            Console.WriteLine("Ürün güncellendi");
        }
    }
    class Kategori : ISinifGereksinimleri, IVeritabaniIslemleri
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool ShowTopMenu { get; set; }

        public void Add()
        {
            Console.WriteLine("Kategori eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("Kategori silindi");
        }

        public void GetAll()
        {
            Console.WriteLine("Kategori listelendi");
        }

        public void Update()
        {
            Console.WriteLine("Kategori güncellendi");
        }
    }
    class Marka : ISinifGereksinimleri, IVeritabaniIslemleri
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Logo { get; set; }

        public void Add()
        {
            Console.WriteLine("Marka eklendi");
        }

        public void Delete()
        {
            Console.WriteLine("Marka silindi");
        }

        public void GetAll()
        {
            Console.WriteLine("Marka listelendi");
        }

        public void Update()
        {
            Console.WriteLine("Marka güncellendi");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interfaces, Arayüzler!");
            Marka marka = new Marka();
            marka.Add();
            Kategori kategori = new Kategori();
            kategori.Update();
            Urun urun = new Urun();
            urun.GetAll();
        }
    }
}