namespace Konu12KalitimInheritance
{
    internal class OrtakOzellikler : OrtakMetotlar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
