using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ass.Models;

namespace Ass.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.RoleName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x=>x.Description).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x=>x.Status).HasColumnType("int").IsRequired();
        }
    }
}
