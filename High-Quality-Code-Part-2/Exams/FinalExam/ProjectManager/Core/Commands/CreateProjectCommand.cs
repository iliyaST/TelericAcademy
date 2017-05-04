using Bytes2you.Validation;
using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pesho.Core.Commands
{
    public class CreateProjectCommand : ICommand
    {
        // string constants
        private const string InvalidParamsMessage = "Invalid command parameters count!";
        private const string EmptyParamMessage = "Some of the passed parameters are empty!";
        private const string ProjectExistMessage = "A project with that name already exists!";
        private const string SuccesfullyCreatedMessage = "Successfully created a new project!";

        // int constants
        private const int MaxParameterCount = 4;

        private Database database;
        private ModelsFactory factory;

        public CreateProjectCommand(Database database, ModelsFactory factory)
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

            if (database.Projects.Any(projct => projct.Name == parameters[0]))
            {
                throw new UserValidationException(ProjectExistMessage);
            }

            var projectName = parameters[0];
            var startingDate = parameters[1];
            var endingDate = parameters[2];
            var projectState = parameters[3];

            var project = factory.CreateProject(projectName, startingDate, endingDate, projectState);

            database.Projects.Add(project);

            return SuccesfullyCreatedMessage;
        }       
    }
}
