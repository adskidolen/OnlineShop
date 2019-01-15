namespace KeepHome.Models
{
    using System.Collections.Generic;

    public class ShoppingBag
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }
        public virtual KeepHomeUser Customer { get; set; }

        public virtual ICollection<ShoppingBagProduct> ShoppingBagProducts { get; set; }

        public ShoppingBag()
        {
            this.ShoppingBagProducts = new HashSet<ShoppingBagProduct>();
        }
    }
}