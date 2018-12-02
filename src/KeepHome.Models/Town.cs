
namespace KeepHome.Models
{
    using System.Collections.Generic;
    public class Town
    {
        public Town()
        {
            this.Users = new HashSet<KeepHomeUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<KeepHomeUser> Users { get; set; }

    }
}