namespace School.Commands
{
    using System.Collections.Generic;
    using Core;
    using Models.Contracts;

    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}
