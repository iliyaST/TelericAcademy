namespace School.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Abstractions;
    using Common;
    using Enums;

    public class Student : Person
    {
        private Grade grades;

        public Student(string firstName, string lastName, Grade grades)
            : base(firstName, lastName)
        {
            this.Grades = grades;
            this.Marks = new List<Mark>();
        }

        internal List<Mark> Marks { get; set; }

        private Grade Grades
        {
            get
            {
                return this.grades;
            }

            set
            {
                Validator.NumberValue((int)value, Constants.MinGrade, Constants.MaxGrade, Constants.GradeMustBeBetweenMinAndMax);

                this.grades = value;
            }
        }

        public string ListMarks()
        {
            var listedMarks = this.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

            if (listedMarks.Count == 0)
            {
                return "This student has no marks.";
            }

            string studentHas = "The student has this marks:";

            return studentHas + "\n" + string.Join("\n", listedMarks);
        }
    }
}
