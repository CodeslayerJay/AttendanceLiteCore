using AttendanceLite.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceLite.Web.Models.Entities
{
    public class TimeLog : EntityBase
    {
        public LogType Type { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
