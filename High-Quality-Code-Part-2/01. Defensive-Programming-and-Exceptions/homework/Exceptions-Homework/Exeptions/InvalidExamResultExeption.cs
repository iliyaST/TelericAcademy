using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions_HomeworkExeptions
{
    public class InvalidExamResultExeption : Exception
    {
        public InvalidExamResultExeption()
        {

        }

        public InvalidExamResultExeption(string message)
            :base(message)
        {

        }
    }
}
