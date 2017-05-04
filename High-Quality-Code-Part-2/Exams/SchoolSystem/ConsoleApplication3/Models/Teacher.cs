namespace School.Models
{
    using System;
    using Abstractions;
    using Common;
    using Enums;

    public class Teacher : Person
    {
        private string subject;

        public Teacher(string firstName, string lastName, int subject)
            : base(firstName, lastName)
        {
            this.Subject = ((Subjct)subject).ToString();
        }

        public string Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("Invalid subject not found!");
                }

                var subjectMembers = Enum.GetNames(typeof(Subjct));

                if (Array.IndexOf(subjectMembers, value) > -1)
                {
                    this.subject = value;
                }
                else
                {
                    throw new ArgumentException("This subject does not exist!");
                }
            }
        }

        public void AddMark(Student student, float value)
        {
            if (student.Marks.Count > Constants.MaxMarksCount)
            {
                throw new ArgumentException(Constants.MarksCountMustBeLessThanTwenty);
            }

            var currentMarkToAdd = new Mark(this.Subject, value);
            student.Marks.Add(currentMarkToAdd);
        }
    }
}
