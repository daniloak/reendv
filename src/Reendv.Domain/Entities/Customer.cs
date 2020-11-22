using System.Collections.Generic;

namespace Reendv.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
