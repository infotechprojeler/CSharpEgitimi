using System.Collections.Generic;

namespace ClassLibrary2
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Product> Products { get; set; } // virtual ile entity framwork ilişki kurarken otomatik join yapar
    }
}
