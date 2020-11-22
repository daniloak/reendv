using System;

namespace Reendv.Domain.Entities
{
    public class Appointment : Entity
    {
        public Appointment() { }

        public Appointment(Guid customerId, Guid serviceId)
        {
            CustomerId = customerId;
            ServiceId = serviceId;
        }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
