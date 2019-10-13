using System.Collections.Generic;
using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Interfaces;

namespace AttendanceLite.Domain.Interfaces.Repositories
{
    public interface ITimeLogRepository
    {
        void Add(TimeLog timeLog);
        IEnumerable<TimeLog> GetAll(IFilter filter = null);
        TimeLog GetBy(int id);
        void Remove(int id);
    }
}