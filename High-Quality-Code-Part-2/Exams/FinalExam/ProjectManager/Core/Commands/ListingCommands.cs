using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;

namespace ProjectManager.Commands
{
    public class ListProjectsCommand : ICommand
    {
        private Database database;

        public ListProjectsCommand(Database database)
        {
            // guard clause
            Guard.WhenArgument(database, "ListProjectsCommand Database").IsNull().Throw();
            this.database = database;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(parameter => parameter == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.database.Projects);
        }
    }
}
