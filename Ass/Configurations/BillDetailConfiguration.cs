using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;

namespace Ass.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.Id);
            //set thuoc tinh
            builder.Property(x=>x.Price).HasColumnType("int").IsRequired();
            builder.Property(x=>x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x=>x.IdHD).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.Property(x=>x.IdSP).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            //set khoa ngoai
            builder.HasOne(x => x.Bill).WithMany(y=>y.BillDetails).HasForeignKey(c=>c.IdHD);
            builder.HasOne(x => x.Products).WithMany(y => y.BillDetails).HasForeignKey(c => c.IdSP);
        }
    }
}
