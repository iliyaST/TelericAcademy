namespace SchoolSystem.CLI.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            Engine.Students.Remove(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
