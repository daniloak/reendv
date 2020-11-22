using AutoMapper;
using Reendv.Api.ViewModel;
using Reendv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reendv.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
