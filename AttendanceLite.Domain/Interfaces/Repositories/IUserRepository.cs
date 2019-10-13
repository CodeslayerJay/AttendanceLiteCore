using AttendanceLite.Domain.Entities;
using System.Collections.Generic;

namespace AttendanceLite.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll(int skip = 1, int amount = 100);
        User GetBy(int id);
        User GetBy(string username);


        void Remove(int id);
    }
}