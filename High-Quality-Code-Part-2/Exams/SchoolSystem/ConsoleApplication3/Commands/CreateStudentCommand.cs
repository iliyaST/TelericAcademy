namespace School.Commands
{
    using System.Collections.Generic;
    using Core;
    using Models;
    using Models.Contracts;
    using Models.Enums;

    public class CreateStudentCommand : ICommand
    {
        private static int currentstudentID = 0;

        public string Execute(IList<string> parameters)
        {
            Engine.Students.Add(currentstudentID, new Student(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])));
            return $"A new student with name {parameters[0]} {parameters[1]}, grade {(Grade)int.Parse(parameters[2])} and ID {currentstudentID++} was created.";
        }
    }
}
