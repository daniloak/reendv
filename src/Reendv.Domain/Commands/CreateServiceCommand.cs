using Flunt.Notifications;
using Flunt.Validations;
using Reendv.Domain.Commands.Contracts;

namespace Reendv.Domain.Commands
{
    public class CreateServiceCommand : Notifiable, ICommand
    {
        public CreateServiceCommand() { }
        public CreateServiceCommand(string name)
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
