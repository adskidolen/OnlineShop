namespace KeepHome.Models
{
    using System.Collections.Generic;

    public class ChildCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        
        public int ParentCategoryId { get; set; }
        public virtual ParentCategory ParentCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ChildCategory()
        {
            this.Products = new HashSet<Product>();
        }
    }
}