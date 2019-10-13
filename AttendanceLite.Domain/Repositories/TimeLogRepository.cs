using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Filters;
using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceLite.Domain.Repositories
{
    public class TimeLogRepository : ITimeLogRepository
    {
        private List<TimeLog> _timeLogs = new List<TimeLog>();

        public void Add(TimeLog timeLog)
        {
            if (timeLog != null)
                _timeLogs.Add(timeLog);
        }

        public TimeLog GetBy(int id)
        {
            return _timeLogs.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<TimeLog> GetAll(IFilter filter = null)
        {
            if (filter == null)
                filter = new QueryFilter();

            return _timeLogs.Where(x => x.Id > 0).Skip(filter.Skip).Take(filter.Size).ToList();
        }

        public void Remove(int id)
        {
            var timeLog = GetBy(id);
            if (timeLog != null)
                _timeLogs.Remove(timeLog);
        }
    }
}
