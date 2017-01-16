using Academy.Models.Common;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public abstract class Resourse : ILectureResouce
    {
        private string name;
        private string url;

        public Resourse(ResourseType type ,string name,string url,DateTime currentDate)
        {
            this.Type = type;
            this.Name = name;
            this.Url = url;
        }

        public ResourseType Type { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.NullOrEmpty(value, Constants.StringCannotBeNullOrEmpty);
                Validator.StringBetweenNumbers(value, Constants.MinDemoResourseNamelength,
                     Constants.MaxDemoResourseNameLength,
                     String.Format(Constants.ResourseMustBeBetweenMinAndMax,
                     "name", Constants.MinDemoResourseNamelength,
                     Constants.MaxDemoResourseNameLength));

                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                Validator.NullOrEmpty(value, Constants.StringCannotBeNullOrEmpty);
                Validator.StringBetweenNumbers(value, Constants.MinDemoUrlNamelength,
                    Constants.MaxDemoUrlNameLength,
                    String.Format(Constants.ResourseMustBeBetweenMinAndMax,
                    "url", Constants.MinDemoUrlNamelength,
                    Constants.MaxDemoUrlNameLength));

                this.url = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("    * Resource:");
            sb.AppendLine(String.Format("     - Name: {0}", this.Name));
            sb.AppendLine(String.Format("     - Url: {0}", this.Url));
            sb.AppendLine(String.Format("     - Type: {0}", this.Type));

            return sb.ToString();
        }
    }
}
