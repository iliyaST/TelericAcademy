using Academy.Models.Common;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Trainer : User, ITrainer
    {
        public Trainer(string username, string technologies)
            : base(username)
        {
            this.Technologies = technologies.Split(',');
        }

        public IList<string> Technologies { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("* Trainer:");

            sb.Append(base.ToString());

            sb.AppendLine(String.Format(" - Technologies: {0}", String.Join("; ", Technologies)));

            return sb.ToString().TrimEnd();
        }
    }
}
