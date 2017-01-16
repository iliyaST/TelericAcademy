using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using System.Globalization;

namespace Academy.Models
{
    public class PresentationResource : Resourse
    {
        

        public PresentationResource(ResourseType type, string name, string url,DateTime currentDate)
            : base(type, name, url,currentDate)
        {                      
        }
             
    }
}
