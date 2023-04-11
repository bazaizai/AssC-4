using Ass.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;

namespace Ass.Configurations
{
    public class ChatLieuConfiguration : IEntityTypeConfiguration<ChatLieu>
    {
        public void Configure(EntityTypeBuilder<ChatLieu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Ten).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x=>x.Ma).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x=>x.TrangThai).HasColumnType("int").IsRequired();
        }
    }
}
