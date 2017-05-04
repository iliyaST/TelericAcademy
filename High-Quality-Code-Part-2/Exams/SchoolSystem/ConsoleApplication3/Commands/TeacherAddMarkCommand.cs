namespace School.Commands
{
    using System.Collections.Generic;
    using Core;
    using Models.Contracts;

    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);

            // TODO: Check ?
            var student = Engine.Students[studentId];
            var teacher = Engine.Teachers[teacherId];
            teacher.AddMark(student, float.Parse(parameters[2]));
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameters[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
