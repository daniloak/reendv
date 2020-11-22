using Microsoft.EntityFrameworkCore;
using Reendv.Domain.Entities;

namespace Reendv.Infra.Contexts
{
    public class ReendvContext : DbContext
    {
        public ReendvContext(DbContextOptions<ReendvContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReendvContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
