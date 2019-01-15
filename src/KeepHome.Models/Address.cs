namespace KeepHome.Models
{
    using System.Collections.Generic;

    public class Address
    {
        public int Id { get; set; }

        public string Country { get; set; }
        public string Town { get; set; }
        public string Street { get; set; }
        public string OtherDetails { get; set; }

        public string UserId { get; set; }
        public virtual KeepHomeUser User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Address()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}