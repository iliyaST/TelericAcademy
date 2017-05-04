namespace SchoolSystem.CLI.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            return Engine.Students[studentId].ListMarks();
        }
    }
}
