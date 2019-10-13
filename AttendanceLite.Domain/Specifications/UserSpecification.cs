using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Specifications
{
    public class UserSpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User candidate)
        {
            if (candidate.FirstName == null || candidate.LastName == null)
                return false;

            return candidate.LastFourSSN > 0 && candidate.LastFourSSN <= 9999;
        }
    }
}
