using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reendv.Api.ViewModel
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public CustomerDto Customer { get; set; }
        public ServiceDto Service { get; set; }
    }
}
