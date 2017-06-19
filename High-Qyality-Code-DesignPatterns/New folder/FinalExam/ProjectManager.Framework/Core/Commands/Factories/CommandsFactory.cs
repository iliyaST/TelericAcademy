using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data.Factories;
using Ninject;
using ProjectManager.Framework.Core.Commands.Decorators;
using Ninject.Parameters;

namespace ProjectManager.Framework.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IModelsFactory factory;
        private readonly IKernel kernel;

        public CommandsFactory(IModelsFactory factory, IKernel kernel)
        {
            this.factory = factory;
            this.kernel = kernel;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            try
            {
                var command = this.kernel.Get<ICommand>(commandName.ToLower());

                var newCommand = this.kernel.Get<ValidatableCommand>(
                    new[]
                    {
                        new ConstructorArgument("command",command)
                    }
                    );

                return newCommand;
            }
            catch
            {
                throw new UserValidationException("No such command!");
            }
        }
    }
}
