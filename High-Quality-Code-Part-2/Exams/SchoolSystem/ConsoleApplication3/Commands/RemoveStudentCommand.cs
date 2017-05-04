namespace School.Commands
{
    using System.Collections.Generic;
    using Core;
    using Models.Contracts;

    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            Engine.Students.Remove(int.Parse(parameters[0]));
            return $"Student with ID {int.Parse(parameters[0])} was sucessfully removed.";
        }
    }
}
