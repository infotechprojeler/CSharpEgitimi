namespace ClassLibrary1
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product>? Products { get; set; } // 1 kategoriye ait ürün listesi olabilir
        // Bu classlibrary projesini diğer projelerden kullanabilmemiz için o projelerden birinde bu projeyi referans olarak eklemeliyiz yoksa kullanamayız.
        // Referans verme : solution dan bir projeyi genişletip projenin içindeki dependencies(.net framework projelerinde adı references) a sağ tıklayıp add project reference diyerek açılan pencereden class library projesine tik atıp ok diyerek işlemi tamamlıyoruz.
    }
}
