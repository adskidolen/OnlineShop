namespace KeepHome.Models
{
    using KeepHome.Models.Enums;

    using System;

    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string CustomerId { get; set; }
        public virtual KeepHomeUser Customer { get; set; }

        public DateTime CreatedOn { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentType PaymentType { get; set; }

        public Order()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Status = OrderStatus.Pending;
        }
    }
}