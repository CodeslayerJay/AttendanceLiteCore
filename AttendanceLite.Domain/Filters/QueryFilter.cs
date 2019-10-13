using AttendanceLite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Filters
{
    public class QueryFilter : IFilter
    {
        public int Size { get; set; } = 300;
        public int Skip { get; set; }
    }
}
