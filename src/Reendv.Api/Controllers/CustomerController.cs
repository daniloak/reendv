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
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CustomerViewModel> GetAll(
            [FromServices] ICustomerRepository repository
        )
        {
            var customerViewModel = _mapper.Map<IEnumerable<CustomerViewModel>>(repository.GetAll());

            return customerViewModel;
        }

        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateCustomerCommand command,
            [FromServices] CustomerHandler handler
        )
        {
            var result = (GenericCommandResult)handler.Handle(command);
            var customerViewModel = _mapper.Map<CustomerViewModel>(result.Data);

            if (result.Success)
            {
                return CreatedAtAction(nameof(Create), customerViewModel);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
