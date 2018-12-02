namespace KeepHome.Models
{
    using Microsoft.AspNetCore.Identity;

    using System;
    using System.Collections.Generic;

    public class KeepHomeUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual Country Country { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public KeepHomeUser()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}