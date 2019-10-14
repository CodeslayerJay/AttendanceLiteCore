using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Filters;
using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceLite.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _users = context.Users;
        }

        
        public User GetBy(string username)
        {
            var users = _users.Where(x => x.Id > 0 && x.Credentials != null);
            return users.Where(x => x.Credentials.Username == username).SingleOrDefault();
        }
        
    }
}
