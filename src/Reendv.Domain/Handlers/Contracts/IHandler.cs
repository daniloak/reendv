using Reendv.Domain.Commands.Contracts;

namespace Reendv.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
