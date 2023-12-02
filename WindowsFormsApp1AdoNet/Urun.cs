namespace WindowsFormsApp1AdoNet
{
    internal class Urun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
