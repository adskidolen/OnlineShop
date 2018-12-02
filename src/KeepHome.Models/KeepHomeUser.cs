namespace KeepHome.Models
{
    using Microsoft.AspNetCore.Identity;

    public class KeepHomeUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Town Town { get; set; }
        public int TownId { get; set; }
    }
}