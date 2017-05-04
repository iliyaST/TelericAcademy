namespace School.Models.Common
{
    using System;

    public static class Validator
    {
        public static void StringLength(string text, int min, int max, string messege)
        {
            if (text.Length < min || text.Length > max)
            {
                throw new ArgumentException(messege);
            }
        }

        public static void NumberValue(float number, float min, float max, string messege)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(messege);
            }
        }

        public static void NullOrEmpty(string text, string messege)
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
