using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reendv.Domain.Entities;

namespace Reendv.Infra.Mappings
{
    public class AppointmentMapping : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.ServiceId).IsRequired();

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Appointments)
                .HasForeignKey(p => p.CustomerId);

            builder.HasOne(p => p.Service)
                .WithMany()
                .HasForeignKey(p => p.ServiceId);
        }
    }
}
