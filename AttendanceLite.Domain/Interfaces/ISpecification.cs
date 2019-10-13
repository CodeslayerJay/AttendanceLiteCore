using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Interfaces
{
    public interface ISpecification<TCandidate>
    {
        bool IsSatisfiedBy(TCandidate candidate);
    }
}
