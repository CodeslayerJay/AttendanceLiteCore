using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Exceptions
{
    public class TimeLogNullException : Exception
    {
        public TimeLogNullException(string caller) : base($"TimeLog is null / not found. {caller}")
        {

        }
    }
}
