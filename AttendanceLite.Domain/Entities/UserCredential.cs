using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Entities
{
    public class UserCredential : EntityBase
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private byte[] _saltKey;

        public void SetKey(User user, byte[] saltKey)
        {
            if(saltKey.Length > 0 && user.Id == UserId)
            {
                _saltKey = saltKey;
            }
        }

        public byte[] GetKey()
        {
            return _saltKey;
        }
    }
}
