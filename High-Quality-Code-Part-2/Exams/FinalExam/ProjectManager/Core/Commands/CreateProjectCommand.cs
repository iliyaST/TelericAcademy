using Bytes2you.Validation;
using Pesho.Core.Contracts;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.CLI.Core.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private const string InvalidParamsMessage = "Invalid command parameters count!";
        private const string EmptyParamMessage = "Some of the passed parameters are empty!";
        private const string ProjectExistMessage = "A project with that name already exists!";
        private const string SuccesfullyCreatedMessage = "Successfully created a new project!";

        private const int MaxParameterCount = 4;

        private IDatabase database;
        private IModelsFactory factory;

        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != MaxParameterCount)
            {
                throw new UserValidationException(InvalidParamsMessage);
            }

            if (parameters.Any(parameter => parameter == string.Empty))
            {
                throw new UserValidationException(EmptyParamMessage);
            }

            if (this.database.Projects.Any(projct => projct.Name == parameters[0]))
            {
                throw new UserValidationException(ProjectExistMessage);
            }

            var projectName = parameters[0];
            var startingDate = parameters[1];
            var endingDate = parameters[2];
            var projectState = parameters[3];

            var project = this.factory.CreateProject(projectName, startingDate, endingDate, projectState);

            this.database.Projects.Add(project);

            return SuccesfullyCreatedMessage;
        }       
    }
}
