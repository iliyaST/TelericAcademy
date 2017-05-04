namespace SchoolSystem.CLI.Models
{
    using System;
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

        public void AddMark(IStudent student, IMark mark)
        {
            student.Marks.Add(mark);
        }
    }
}
