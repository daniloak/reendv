using Flunt.Notifications;
using Reendv.Domain.Commands;
using Reendv.Domain.Commands.Contracts;
using Reendv.Domain.Entities;
using Reendv.Domain.Handlers.Contracts;
using Reendv.Domain.Repositories;

namespace Reendv.Domain.Handlers
{
    public class ServiceHandler
        : Notifiable,
          IHandler<CreateServiceCommand>
    {
        private readonly IServiceRepository _repository;

        public ServiceHandler(IServiceRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateServiceCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Error creating service", command.Notifications);

            var service = new Service(command.Name);

            _repository.Create(service);

            return new GenericCommandResult(true, "Service created", service);
        }
    }
}
