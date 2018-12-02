namespace KeepHome.Data
{
    using KeepHome.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class KeepHomeContext : IdentityDbContext<KeepHomeUser>
    {
        public KeepHomeContext(DbContextOptions<KeepHomeContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}