using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Exceptions;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Services
{
    public class TimeLogService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITimeLogRepository _timeLogRepo;

        public TimeLogService(IUserRepository userRepository, ITimeLogRepository timeLogRepository)
        {
            _userRepo = userRepository;
            _timeLogRepo = timeLogRepository;
        }
        public void AddLog(TimeLog timeLog)
        {
            if (timeLog == null)
                throw new TimeLogNullException(nameof(AddLog));

            var user = _userRepo.GetBy(timeLog.UserId);

            if (user == null)
                throw new UserNullException(nameof(AddLog));

            _timeLogRepo.Add(timeLog);
            user.AddLog(timeLog);

        }

        public void DeleteLog(int id)
        {
            _timeLogRepo.Remove(id);
        }
    }
}
