using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            _timeLogs = new HashSet<TimeLog>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LastFourSSN { get; set; }

        public UserRole Role { get; set; }
        public UserCredential Credentials { get; set; }

        private ICollection<TimeLog> _timeLogs;

        public void AddLog(TimeLog log)
        {
            if(log != null && log.UserId == Id)
            {
                _timeLogs.Add(log);
            }
        }

        public IEnumerable<TimeLog> GetTimeLogs()
        {
            return _timeLogs;
        }

    }
}
