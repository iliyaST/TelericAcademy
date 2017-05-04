namespace ConsoleApplication3.Core.Commands
{
    using System.Collections.Generic;
    using SchoolSystem.CLI.Core;
    using SchoolSystem.CLI.Core.Commands.Contracts;

    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            Engine.Teachers.Remove(teacherId);

            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
