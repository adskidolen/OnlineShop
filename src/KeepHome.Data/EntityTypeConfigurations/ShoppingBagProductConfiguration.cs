namespace KeepHome.Data.EntityTypeConfigurations
{
    using KeepHome.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoppingBagProductConfiguration : IEntityTypeConfiguration<ShoppingBagProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingBagProduct> builder)
        {
            builder.HasKey(pk => new
            {
                pk.ProductId,
                pk.ShoppingBagId
            });
        }
    }
}