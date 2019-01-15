namespace KeepHome.Data
{
    using KeepHome.Data.EntityTypeConfigurations;
    using KeepHome.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class KeepHomeContext : IdentityDbContext<KeepHomeUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ParentCategory> ParentCategories { get; set; }
        public DbSet<ChildCategory> ChildCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<ShoppingBagProduct> ShoppingBagsProducts { get; set; }

        public KeepHomeContext(DbContextOptions<KeepHomeContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShoppingBagProductConfiguration());
            builder.ApplyConfiguration(new ShoppingBagConfiguration());

            base.OnModelCreating(builder);
        }
    }
}