using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;

namespace Ass.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.IDSP).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.UserID).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.HasOne(x=>x.Product).WithMany(y=>y.CartDetails).HasForeignKey(x => x.IDSP);
            builder.HasOne(x => x.Cart).WithMany(y => y.CartDetails).HasForeignKey(x => x.UserID);
        }
    }
}
