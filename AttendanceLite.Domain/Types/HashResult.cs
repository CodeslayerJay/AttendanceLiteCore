using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Types
{
    public class HashResult
    {
        public string HashedPassword { get; set; }
        public byte[] SaltKey { get; set; }

    }
}
