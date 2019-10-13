using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Interfaces
{
    public interface IFilter
    {
        int Size { get; set; }
        int Skip { get; set; }
    }
}
