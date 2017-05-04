using System;

namespace ProjectManager.CLI.Common
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message)
            : base(" - Error: " + message)
        {
        }
    }
}
