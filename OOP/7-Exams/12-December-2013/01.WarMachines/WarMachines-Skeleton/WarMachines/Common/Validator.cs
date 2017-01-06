
namespace WarMachines.Common
{
    using System;

    public class Validator
    {
        public static void ValidateString(string text, string property)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(String.Format(Constants.StringCannotBeNullOrEmpty), property);
            }
        }

        public static void ValidateNull(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(Constants.MachineCannotBeNull);
            }
        }
    }
}
