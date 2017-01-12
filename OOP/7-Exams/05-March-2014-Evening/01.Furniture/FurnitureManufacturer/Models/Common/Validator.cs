
namespace FurnitureManufacturer.Models.Common
{
    using System;

    public static class Validator
    {
        public static void StringIsNullOrEmpty(string text,string message)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException();
            }
        }

        public static void IsNull(object obj)
        {
            if(obj == null)
            {
                throw new ArgumentException(Constants.ObjectNull);
            }
        }

        public static void ContainsOnlyNumbers(string text,string message)
        {
            for(int i = 0; i < text.Length; i++)
            {
                if (!Char.IsNumber(text[i]))
                {
                    throw new ArgumentException(message);
                }
            }
        }
    }
}
