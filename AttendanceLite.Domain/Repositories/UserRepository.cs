using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Filters;
using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceLite.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public void Add(User user)
        {
            if (user != null)
                _users.Add(user);
        }

        public User GetBy(string username)
        {
            var users = _users.Where(x => x.Id > 0 && x.Credentials != null);
            return users.Where(x => x.Credentials.Username == username).SingleOrDefault();
        }
        public User GetBy(int id)
        {
            return _users.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<User> GetAll(IFilter filter = null)
        {
            if (filter == null)
                filter = new QueryFilter();

            return _users.Where(x => x.Id > 0).Skip(filter.Skip).Take(filter.Size).ToList();
        }

        public void Remove(int id)
        {
            var user = GetBy(id);
            if (user != null)
                _users.Remove(user);
        }

    }
}
