using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reendv.Domain.Entities;

namespace Reendv.Infra.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();
        }
    }
}
