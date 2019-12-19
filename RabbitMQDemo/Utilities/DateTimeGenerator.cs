using System;
using Utilities.Contracts;

namespace Utilities
{
    public class DateTimeGenerator : IDateTimeGenerator
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
