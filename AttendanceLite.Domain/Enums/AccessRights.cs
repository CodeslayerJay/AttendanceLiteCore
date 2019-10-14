using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Enums
{
    [Flags]
    public enum AccessRights
    {
        None = 0,
        Basic = 1,
        Moderator = 2,
        Admin = 4,
        All = 7
    }
}
