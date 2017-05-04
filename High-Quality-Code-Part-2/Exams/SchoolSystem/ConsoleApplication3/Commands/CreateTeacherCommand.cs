namespace School.Commands
{
    using System.Collections.Generic;
    using Core;
    using Models;
    using Models.Contracts;
    using Models.Enums;

    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            Engine.Teachers.Add(id, new Teacher(parameters[0], parameters[1], int.Parse(parameters[2])));
            return $"A new teacher with name {parameters[0]} {parameters[1]}, subject {(Subjct)int.Parse(parameters[2])} and ID {id++} was created.";
        }
    }
}
