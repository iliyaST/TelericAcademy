using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core.Commands.Contracts;
using ProjectManager.CLI.Data.Contracts;

namespace ProjectManager.CLI.Core.Commands
{
    public class ListProjectDetails : ICommand
    {
        private IDatabase database;

        public ListProjectDetails(IDatabase database)
        {
            Guard.WhenArgument(database, "ListProjectsCommand Database").IsNull().Throw();
            this.database = database;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            var projectId = int.Parse(parameters[0]);

            if (projectId < 0 || projectId > this.database.Projects.Count)
            {
                throw new UserValidationException("Such project does not exist!");
            }

            var project = this.database.Projects[projectId];

            var resultProject = string.Format("{0}", project);

            return resultProject;
        }
    }
}
