using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using System.Globalization;

namespace Academy.Models
{
    public class HomeworkResource : Resourse
    {
        public HomeworkResource(ResourseType type, string name, string url, DateTime currentDate)
            : base(type, name, url, currentDate)
        {
            this.DueDate = currentDate;
            DueDate = DueDate.AddDays(7);
        }

        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendLine(string.Format("     - Due date: {0}",
                this.DueDate.ToString("yyyy-MM-dd hh:mm:ss " + "tt", CultureInfo.InvariantCulture)));

            return sb.ToString().TrimEnd();
        }
    }
}
