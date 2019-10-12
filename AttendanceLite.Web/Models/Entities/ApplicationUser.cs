using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceLite.Web.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public byte LastFourSSN { get; set; }

    }
}
