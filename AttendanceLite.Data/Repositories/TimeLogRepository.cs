using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Filters;
using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceLite.Data.Repositories
{
    public class TimeLogRepository : RepositoryBase<TimeLog>, ITimeLogRepository
    {
        private readonly DbSet<TimeLog> _timeLogs;

        public TimeLogRepository(ApplicationDbContext context) : base(context)
        {
            _timeLogs = context.TimeLogs;
        }
    }
}
