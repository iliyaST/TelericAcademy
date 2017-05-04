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
        public Database database;
        public ModelsFactory factory;

        public string Execute(List<string> prms)
        {
            if (prms.Count != 4) throw new UserValidationException("Invalid command parameters count!");
            if (prms.Any(x => x == string.Empty)) throw new UserValidationException("Some of the passed parameters are empty!");
            if (database.Projects.Any(x => x.Name == prms[0])) throw new UserValidationException("A project with that name already exists!");

            var project = factory.CreateProject(prms[0], prms[1], prms[2], prms[3]);
            database.Projects.Add(project);

            return "Successfully created a new project!";
        }

        public CreateProjectCommand(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database").IsNull().Throw();
            Guard.WhenArgument(
                factory, "CreateProjectCommand ModelsFactory")
                .IsNull().Throw();

            this.database = database;
            this.factory = factory;
        }
    }
}
