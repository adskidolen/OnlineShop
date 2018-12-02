namespace KeepHome.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string CustomerId { get; set; }
        public virtual KeepHomeUser Customer { get; set; }
    }
}