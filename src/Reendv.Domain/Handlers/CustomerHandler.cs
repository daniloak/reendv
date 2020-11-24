using Flunt.Notifications;
using Reendv.Domain.Commands;
using Reendv.Domain.Commands.Contracts;
using Reendv.Domain.Entities;
using Reendv.Domain.Handlers.Contracts;
using Reendv.Domain.Repositories;

namespace Reendv.Domain.Handlers
{
    public class CustomerHandler
        : Notifiable,
          IHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error creating customer", command.Notifications);

            var customer = new Customer(command.Name);

            _repository.Create(customer);

            return new GenericCommandResult(true, "Customer created", customer);
        }
    }
}
