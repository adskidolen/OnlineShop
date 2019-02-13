namespace KeepHome.Models
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public DateTime AddedOn { get; set; }

        public int ChildCategoryId { get; set; }
        public virtual ChildCategory ChildCategory { get; set; }

        public virtual ICollection<ShoppingBagProduct> ShoppingBagProducts { get; set; }

        public Product()
        {
            this.AddedOn = DateTime.UtcNow;
            this.ShoppingBagProducts = new HashSet<ShoppingBagProduct>();
        }
    }
}