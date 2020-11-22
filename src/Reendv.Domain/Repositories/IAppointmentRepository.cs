using Reendv.Domain.Entities;
using System.Collections.Generic;

namespace Reendv.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        void Create(Appointment appointment);
        IEnumerable<Appointment> GetAll();
    }
}
