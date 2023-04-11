using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;

namespace Ass.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x=>x.Description).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
