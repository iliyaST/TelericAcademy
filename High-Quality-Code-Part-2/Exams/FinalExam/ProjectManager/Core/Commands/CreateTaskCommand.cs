using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{

    public sealed class CreateTaskCommand : ICommand
    {
        public string Execute(List<string> commandParameters)
        {
            var database = new Database();

            var factory = new ModelsFactory();

            if (commandParameters.Count != 4) throw new UserValidationException("Invalid command parameters count!");

            if (commandParameters.Any(x => x == string.Empty)) throw new UserValidationException("Some of the passed parameters are empty!");
            
            var pj = database.Projects[int.Parse(commandParameters[0])];

            var owner = pj.Users[int.Parse(commandParameters[1])];

            var task = factory.CreateTask(owner, commandParameters[2], commandParameters[3]);
            pj.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
