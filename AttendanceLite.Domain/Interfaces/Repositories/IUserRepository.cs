using AttendanceLite.Domain.Entities;
using System.Collections.Generic;

namespace AttendanceLite.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll(IFilter filter);
        User GetBy(int id);
        User GetBy(string username);


        void Remove(int id);
    }
}