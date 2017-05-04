namespace SchoolSystem.CLI.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameteres)
        {
            var teacherId = int.Parse(parameteres[0]);
            var studentId = int.Parse(parameteres[1]);

            var student = Engine.Students[studentId];
            var teacher = Engine.Teachers[teacherId];
            var markValue = float.Parse(parameteres[2]);
            var mark = new Mark(teacher.Subject, markValue);

            teacher.AddMark(student, mark);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameteres[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
