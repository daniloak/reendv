using Flunt.Notifications;
using Flunt.Validations;
using Reendv.Domain.Commands.Contracts;
using System;

namespace Reendv.Domain.Commands
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public CreateCustomerCommand(){}
        public CreateCustomerCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
            );
        }
    }
}
