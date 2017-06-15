using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Providers;
using Ninject;

namespace ProjectManager.Framework.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IDatabase database;
        private readonly IModelsFactory factory;
        private readonly IKernel kernel;

        public CommandsFactory(IModelsFactory factory,IKernel kernel)
        {
            this.factory = factory;
            this.kernel = kernel;
        }

        public ICommand GetCommandFromString(string commandName)
        {
            try
            {
                return this.kernel.Get<ICommand>(commandName.ToLower());
            }
            catch
            {
                throw new UserValidationException("No such command!");
            }
        }     
    }
}
