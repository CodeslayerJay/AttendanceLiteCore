using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceLite.Web.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            TimeLogs = new HashSet<TimeLog>();
        }

        public byte LastFourSSN { get; set; }

        public ICollection<TimeLog> TimeLogs { get; set; }

    }
}
