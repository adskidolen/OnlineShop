using System.Collections.Generic;

namespace KeepHome.Models
{
    using KeepHome.Models.Enums;

    using System;

    public class Order
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }
        public virtual KeepHomeUser Customer { get; set; }

        public int? DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentType PaymentType { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        

        public Order()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Status = OrderStatus.Pending;
            this.OrderProducts = new HashSet<OrderProduct>();
        }
    }
}