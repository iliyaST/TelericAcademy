namespace SchoolSystem.CLI.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Enums;

    public class CreateStudentCommand : ICommand
    {
        private static int studentId = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var studentGrade = (Grade)int.Parse(parameters[2]);

            var student = new Student(firstName, lastName, studentGrade);
            Engine.Students.Add(studentId, student);

            return $"A new student with name {firstName} {lastName}, grade {studentGrade} and ID {studentId++} was created.";
        }
    }
}
