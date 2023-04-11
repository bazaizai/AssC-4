using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;
using System.Runtime.CompilerServices;

namespace Ass.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
           // builder.ToTable("HoaHon");// đặt tên cho bảng 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.status).HasColumnType("int").IsRequired();
            builder.Property(x => x.UserId).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.HasOne(x => x.User).WithMany(y => y.Bills).HasForeignKey(x => x.UserId);

        }
    }
}
