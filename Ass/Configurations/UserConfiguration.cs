using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;
using System.Runtime.CompilerServices;

namespace Ass.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Username).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x=>x.Password).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x=>x.Status).HasColumnType("int").IsRequired();
            builder.Property(x=>x.RoleID).HasColumnType("UNIQUEIDENTIFIER ").IsRequired();
            builder.HasOne(x=>x.Roles).WithMany(y=>y.Users).HasForeignKey(x=>x.RoleID);
        }
    }
}
