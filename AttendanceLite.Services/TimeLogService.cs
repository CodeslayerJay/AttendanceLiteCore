using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Exceptions;
using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Services
{
    public class TimeLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddLog(TimeLog timeLog)
        {
            if (timeLog == null)
                throw new TimeLogNullException(nameof(AddLog));

            var user = _unitOfWork.Users.GetBy(timeLog.UserId);

            if (user == null)
                throw new UserNullException(nameof(AddLog));

            _unitOfWork.TimeLogs.Add(timeLog);
            user.AddLog(timeLog);
            _unitOfWork.SaveChanges();
        }

        public void DeleteLog(int id)
        {
            var timeLog = _unitOfWork.TimeLogs.GetBy(id);

            if(timeLog != null)
            {
                _unitOfWork.TimeLogs.Remove(id);
            }

        }
    }
}
