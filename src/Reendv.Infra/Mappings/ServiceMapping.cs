using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reendv.Domain.Entities;

namespace Reendv.Infra.Mappings
{
    public class ServiceMapping : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasIndex(p => p.Description)
                .IsUnique();
        }
    }
}
