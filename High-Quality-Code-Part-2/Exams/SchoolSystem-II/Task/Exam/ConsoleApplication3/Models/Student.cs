namespace SchoolSystem.CLI.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;
    using Enums;
    using Models.Contracts;

    public class Student : Person, IStudent
    {
        private const string StudentHasNoMarks = "This student has no marks.";
        private Grade grade;

        public Student(string firstName, string lastName, Grade grade)
          : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public IList<IMark> Marks { get; set; }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                this.grade = value;
            }
        }

        public string ListMarks()
        {
            if (this.Marks.Count != 0)
            {
                var studentHasMarks = "The student has these marks:\n";
                var listedMarksFormated = this.Marks.Select(mark => $"{mark.Subject} => {mark.Value}").ToList();
                return studentHasMarks + string.Join("\n", listedMarksFormated) + "\n";
            }
            else
            {
                return StudentHasNoMarks;
            }
        }
    }
}
