using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils.Contracts;
using Academy.Models.Common;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class Student : User, IStudent
    {
        public Student(string username, string track) :
            base(username)
        {
            this.Track = (Track)Enum.Parse(typeof(Track), track);
            this.CourseResults = new List<ICourseResult>();
        }

        public IList<ICourseResult> CourseResults { get; set; }

        public Track Track { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("* Student:");
            sb.Append(base.ToString());
            sb.AppendLine(String.Format(" - Track:",this.Track));
            sb.AppendLine(" - Course results:");

            if (this.CourseResults.Count == 0)
            {
                sb.AppendLine("  * User has no course results!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
