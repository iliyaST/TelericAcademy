namespace SchoolSystem.CLI.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameteres)
        {
            var teacherId = int.Parse(parameteres[0]);
            var studentId = int.Parse(parameteres[1]);

            var student = Engine.Instance.Students[studentId];
            var teacher = Engine.Instance.Teachers[teacherId];

            teacher.AddMark(student, float.Parse(parameteres[2]));

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameteres[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
