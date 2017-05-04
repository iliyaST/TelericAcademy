using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pesho.Core.Commands
{
    public class CreateUserCommand : ICommand
    {    
        public string Execute(List<string> prms)
        {
            var db = new Database();

            var zavoda = new ModelsFactory();

            if (prms.Count != 3) throw new UserValidationException("Invalid command parameters count!");
            if (prms.Any(x => x == string.Empty)) throw new UserValidationException("Some of the passed parameters are empty!");

            if (db.Projects[int.Parse(prms[0])].Users.Any() && db.Projects[int.Parse(prms[0])].Users.Any(x => x.UN == prms[1]))
                throw new UserValidationException("A user with that username already exists!");

            db.Projects[int.Parse(prms[0])].Users.Add(zavoda.CreateUser(prms[1], prms[2]));

            return "Successfully created a new user!";
        }
    }
}
