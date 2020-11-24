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
    public class ServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ServiceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ServiceViewModel> GetAll(
            [FromServices] IServiceRepository repository
        )
        {
            var serviceViewModel = _mapper.Map<IEnumerable<ServiceViewModel>>(repository.GetAll());

            return serviceViewModel;
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateServiceCommand command,
            [FromServices] ServiceHandler handler
        )
        {
            var result = (GenericCommandResult)handler.Handle(command);
            var serviceViewModel = _mapper.Map<ServiceViewModel>(result.Data);

            if (result.Success)
            {
                return CreatedAtAction(nameof(Create), serviceViewModel);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
