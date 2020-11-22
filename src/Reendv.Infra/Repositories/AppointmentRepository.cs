using Microsoft.EntityFrameworkCore;
using Reendv.Domain.Entities;
using Reendv.Domain.Repositories;
using Reendv.Infra.Contexts;
using System.Collections.Generic;

namespace Reendv.Infra.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ReendvContext _context;
        public AppointmentRepository(ReendvContext context)
        {
            _context = context;
        }

        public void Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.AsNoTracking()
                    .Include(p => p.Customer)
                    .Include(p => p.Service);
        }
    }
}
