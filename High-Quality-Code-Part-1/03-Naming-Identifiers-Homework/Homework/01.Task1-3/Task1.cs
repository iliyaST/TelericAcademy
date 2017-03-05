namespace NamingIdentifiers
{
    using System;

    public class Printer
    {
        private const int MaxCount = 6;
      
        public static void Print(string value)
        {
            Console.WriteLine(value);
        }

        public static void Main()
        {
            var obj = new StringConverter();
            var convertedBoolValue = obj.ConvertBoolToString(true);

            Print(convertedBoolValue);
        }

        public class StringConverter
        {
            public string ConvertBoolToString(bool inputValue)
            {
                string convertedValue = inputValue.ToString();

                return convertedValue;
            }
        }
    }
}
