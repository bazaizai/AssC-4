using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;
using System.Runtime.CompilerServices;

namespace Ass.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.IdMauSac).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.IdChatLieu).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.IdTeam).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x => x.SoLuongTon).HasColumnType("int ").IsRequired();
            builder.Property(x => x.GiaBan).HasColumnType("int ").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000) ").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.HasOne(x => x.MauSac).WithMany(y => y.Products).HasForeignKey(x => x.IdMauSac);
            builder.HasOne(x => x.ChatLieu).WithMany(y => y.Products).HasForeignKey(x => x.IdChatLieu);
            builder.HasOne(x => x.Team).WithMany(y => y.Products).HasForeignKey(x => x.IdTeam);
        }
    }
}
