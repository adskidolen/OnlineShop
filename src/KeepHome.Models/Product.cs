using System.Collections.Generic;

namespace KeepHome.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public int ChildCategoryId { get; set; }
        public virtual ChildCategory ChildCategory { get; set; }

        public virtual ICollection<ShoppingBagProduct> ShoppingBagProducts { get; set; }

        public Product()
        {
            this.ShoppingBagProducts = new HashSet<ShoppingBagProduct>();
        }
    }
}