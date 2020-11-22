using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reendv.Api.ViewModel;
using Reendv.Domain.Commands;
using Reendv.Domain.Entities;
using Reendv.Domain.Handlers;
using Reendv.Domain.Repositories;

namespace Reendv.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        public AppointmentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AppointmentDto> GetAll(
            [FromServices] IAppointmentRepository repository
        )
        {
            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(repository.GetAll());

            return appointmentsDto;
        }

        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateAppointmentCommand command, 
            [FromServices]AppointmentHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
