using Academy.Models.Common;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class DemoResource : Resourse
    {
        public DemoResource(ResourseType type, string name, string url,DateTime currentDate) 
            : base(type, name, url,currentDate)
        {
        }
    }
}
