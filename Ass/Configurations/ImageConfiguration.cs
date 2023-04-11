using Ass.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ass.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>

    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DuongDan).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.IdChiTietSp).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.TrangThai).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Product).WithMany(y => y.Images).HasForeignKey(x => x.IdChiTietSp);
        }
    }
}
