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
    public class Lecture : ILecture
    {
        private string name;

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(date);
            this.Trainer = trainer;
            this.Resouces = new List<ILectureResouce>();
        }

        public DateTime Date { get; set; }

        public ITrainer Trainer { get; set; }

        public IList<ILectureResouce> Resouces { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.NullOrEmpty(value, String.Format(Constants.StringCannotBeNullOrEmpty
                    , nameof(Name)));

                Validator.StringBetweenNumbers(value, Constants.MinLectureNameLength,
                    Constants.MaxLectureNameLength,
                    Constants.LectureNameMustBeBetweenMinAndMax);

                this.name = value;
            }
        }      

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("  * Lecture:");
            sb.AppendLine(String.Format("   - Name: {0}", this.Name));
            sb.AppendLine(String.Format("   - Date: {0}", this.Date.ToString("yyyy-MM-dd hh:mm:ss " + "tt", CultureInfo.InvariantCulture)));
            sb.AppendLine(String.Format("   - Trainer username: {0}", this.Trainer.Username));
            sb.AppendLine("   - Resources:");

            if (this.Resouces.Count == 0)
            {
                sb.AppendLine("    * There are no resources in this lecture.");
            }
            else
            {
                foreach (var resourse in this.Resouces)
                {
                    sb.AppendLine(resourse.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
