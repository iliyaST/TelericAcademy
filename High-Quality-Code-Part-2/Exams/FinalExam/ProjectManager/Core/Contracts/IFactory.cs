using ProjectManager.Commands;

namespace Pesho.Core.Contracts
{
    public interface IFactory
    {
        ICommand CreateCommandFromString(string commandName);


    }
}
