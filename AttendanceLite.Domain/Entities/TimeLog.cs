using AttendanceLite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Entities
{
    public class TimeLog : EntityBase
    {
        public LogType Type { get; set; } = LogType.SelfStamped;
        public bool IsCheckedIn { get; set; }
    }
}
