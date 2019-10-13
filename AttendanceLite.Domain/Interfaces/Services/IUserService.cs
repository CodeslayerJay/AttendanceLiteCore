using AttendanceLite.Domain.Entities;

namespace AttendanceLite.Domain.Interfaces.Services
{
    public interface IUserService
    {
        void RegisterUser(User user);
        void SaveUserCredentials(UserCredential userCred);
        bool VerifyUserCredentials(string username, string password);
    }
}