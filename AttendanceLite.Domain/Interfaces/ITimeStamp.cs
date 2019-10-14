using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Interfaces
{
    public interface ITimeStamp
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
