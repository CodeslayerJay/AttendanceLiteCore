using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Exceptions
{
    public class UserNullException : Exception
    {
        public UserNullException(string caller) : base($"User is null / not found. { caller }")
        { }

    }
}
