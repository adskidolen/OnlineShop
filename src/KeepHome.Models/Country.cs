namespace KeepHome.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
            this.Users = new HashSet<KeepHomeUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
        public virtual ICollection<KeepHomeUser> Users { get; set; }
    }
}