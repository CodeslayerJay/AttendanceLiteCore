using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int LastFourSSN { get; set; }

        public UserRole Role { get; set; }
        public UserCredential Credentials { get; set; }
    }
}
