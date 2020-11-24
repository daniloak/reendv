using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reendv.Api.ViewModel
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ServiceViewModel Service { get; set; }
    }
}
