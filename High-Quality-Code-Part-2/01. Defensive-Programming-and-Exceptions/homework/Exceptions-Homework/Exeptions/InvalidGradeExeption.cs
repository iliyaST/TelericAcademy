using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_Homework.Exeptions
{
    public class InvalidGradeExeption : Exception
    {
        public InvalidGradeExeption()
        {

        }

        public InvalidGradeExeption(string message)
            :base(message)
        {

        }
    }
}
