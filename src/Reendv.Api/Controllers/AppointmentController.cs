using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reendv.Api.ViewModel;
using Reendv.Domain.Commands;
using Reendv.Domain.Handlers;
using Reendv.Domain.Repositories;
using System.Collections.Generic;

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
        public IEnumerable<AppointmentViewModel> GetAll(
            [FromServices] IAppointmentRepository repository
        )
        {
            var appointmentViewModel = _mapper.Map<IEnumerable<AppointmentViewModel>>(repository.GetAll());

            return appointmentViewModel;
        }

        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateAppointmentCommand command,
            [FromServices] AppointmentHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
