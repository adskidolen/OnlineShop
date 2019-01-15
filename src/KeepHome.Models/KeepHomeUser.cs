namespace KeepHome.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.Collections.Generic;

    public class KeepHomeUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual  ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int ShoppingBagId { get; set; }
        public virtual ShoppingBag ShoppingBag { get; set; }

        public KeepHomeUser()
        {
            this.Addresses = new HashSet<Address>();
            this.Orders = new HashSet<Order>();
        }
    }
}