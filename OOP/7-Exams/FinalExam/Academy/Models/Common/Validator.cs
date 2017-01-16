using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Common
{
    public static class Validator
    {
        public static void StringBetweenNumbers(string text, int min, int max, string messege)
        {
            if (text.Length < min || text.Length > max)
            {
                throw new ArgumentException(messege);
            }
        }

        public static void NumberBetweenNumbers(int number, int min, int max, string messege)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(messege);
            }
        }

        public static void NullOrEmpty(string text,string messege)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(messege);
            }
        }

        public static void ValidateNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
