namespace SchoolSystem.CLI.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Enums;

    public class CreateTeacherCommand : ICommand
    {
        private static int teacherId = 0;

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = new Teacher(firstName, lastName, subject);
            Engine.Instance.Teachers.Add(teacherId, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {teacher.Subject} and ID {teacherId++} was created.";
        }
    }
}
