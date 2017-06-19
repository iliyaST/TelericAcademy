using ProjectManager.Framework.Core.Common.Contracts;
using System;

namespace ProjectManager.Tests
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDate()
        {
            return new DateTime(2017, 6, 15, 0, 0, 0);
        }
    }
}
