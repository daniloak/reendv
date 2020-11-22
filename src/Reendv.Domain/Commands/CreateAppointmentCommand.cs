using Flunt.Notifications;
using Flunt.Validations;
using Reendv.Domain.Commands.Contracts;
using System;

namespace Reendv.Domain.Commands
{
    public class CreateAppointmentCommand : Notifiable, ICommand
    {
        public CreateAppointmentCommand(Guid customer, Guid service)
        {
            Customer = customer;
            Service = service;
        }

        public Guid Customer { get; set; }
        public Guid Service { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
            );
        }
    }
}
