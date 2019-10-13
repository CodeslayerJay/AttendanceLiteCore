using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Specifications
{
    public class UserCredentialSpecification : ISpecification<UserCredential>
    {
        public bool IsSatisfiedBy(UserCredential candidate)
        {
            if (candidate.UserId == 0)
                return false;

           return candidate.Username != null && candidate.Password != null;
        }
    }
}
