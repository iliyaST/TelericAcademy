namespace SchoolSystem.CLI.Models
{
    using Abstractions;
    using Enums;
    using Models.Contracts;

    public class Teacher : Person, ITeacher
    {
        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float value)
        {
            var mark = new Mark(this.Subject, value);
            student.Marks.Add(mark);
        }
    }
}
