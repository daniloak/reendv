using Flunt.Notifications;
using Reendv.Domain.Commands;
using Reendv.Domain.Commands.Contracts;
using Reendv.Domain.Entities;
using Reendv.Domain.Handlers.Contracts;
using Reendv.Domain.Repositories;
using System;

namespace Reendv.Domain.Handlers
{
    public class AppointmentHandler
        : Notifiable,
          IHandler<CreateAppointmentCommand>
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateAppointmentCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "erro", command.Notifications);

            var appointment = new Appointment(command.Customer, command.Service);

            _repository.Create(appointment);

            return new GenericCommandResult(true, "Sucesso", appointment);
        }
    }
}
