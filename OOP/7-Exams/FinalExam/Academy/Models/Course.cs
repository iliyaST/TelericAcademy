using Academy.Models.Common;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = Convert.ToInt32(lecturesPerWeek);
            this.StartingDate = DateTime.Parse(startingDate);
            this.OnlineStudents = new List<IStudent>();
            this.OnsiteStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
            this.EndingDate = StartingDate.AddDays(30);

        }

        public DateTime EndingDate { get; set; }

        public IList<ILecture> Lectures { get; set; }

        public IList<IStudent> OnlineStudents { get; }

        public IList<IStudent> OnsiteStudents { get; }

        public DateTime StartingDate { get; set; }


        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                Validator.NumberBetweenNumbers(value, Constants.MinNumberOfCourses,
                    Constants.MaxNumberOfCourses,
                    String.Format(Constants.NumberMustBeBetweenMinAndMax));

                this.lecturesPerWeek = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.NullOrEmpty(value, String.Format(Constants.StringCannotBeNullOrEmpty,
                    nameof(Name)));

                Validator.StringBetweenNumbers(value, Constants.MinCourseNameLength
                    , Constants.MaxCourseNameLength,
                    Constants.StringMustBeBetweenMinAndMax);

                this.name = value;
            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("* Course:");

            sb.AppendLine(String.Format(" - Name: {0}", this.Name));
            sb.AppendLine(String.Format(" - Lectures per week: {0}", this.LecturesPerWeek));
            sb.AppendLine(String.Format(" - Starting date: {0}", this.StartingDate.ToString("yyyy-MM-dd hh:mm:ss " + "tt", CultureInfo.InvariantCulture)));
            sb.AppendLine(String.Format(" - Ending date: {0}", this.EndingDate.ToString("yyyy-MM-dd hh:mm:ss " + "tt", CultureInfo.InvariantCulture)));
            sb.AppendLine(String.Format(" - Onsite students: {0}", this.OnsiteStudents.Count));
            sb.AppendLine(String.Format(" - Online students: {0}", this.OnlineStudents.Count));
            sb.AppendLine(" - Lectures:");

            if (this.Lectures.Count == 0)
            {
                sb.AppendLine("  * There are no lectures in this course!");

            }

            return sb.ToString().TrimEnd();
        }
    }
}
