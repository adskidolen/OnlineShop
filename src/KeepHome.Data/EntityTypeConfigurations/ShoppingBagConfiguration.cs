namespace KeepHome.Data.EntityTypeConfigurations
{
    using KeepHome.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoppingBagConfiguration : IEntityTypeConfiguration<ShoppingBag>
    {
        public void Configure(EntityTypeBuilder<ShoppingBag> builder)
        {
            builder.HasOne(c => c.Customer)
                   .WithOne(shb => shb.ShoppingBag)
                   .HasForeignKey<KeepHomeUser>(fk => fk.ShoppingBagId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}