using AttendanceLite.Domain.Enums;
using AttendanceLite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Entities
{
    public class TimeLog : EntityBase
    {
        public int UserId { get; set; }
        public LogType Type { get; set; } = LogType.SelfStamped;
        public bool IsCheckedIn { get; set; }
        
        public User User { get; set; }
    }
}
