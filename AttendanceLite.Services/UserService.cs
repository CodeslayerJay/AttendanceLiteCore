using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Exceptions;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using AttendanceLite.Domain.Specifications;
using AttendanceLite.Domain.Interfaces.Services;

namespace AttendanceLite.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public void RegisterUser(User user)
        {
            if (user == null)
                throw new UserNullException(nameof(RegisterUser));

            var userSpec = new UserSpecification();
            if (!userSpec.IsSatisfiedBy(user))
                throw new Exception("User did not pass validation. One or more arguments is null.");

            _userRepository.Add(user);

        }

        public void SaveUserCredentials(UserCredential userCred)
        {

            var user = _userRepository.GetBy(userCred.UserId);

            if (user == null)
                throw new UserNullException($"User not found with id {userCred.UserId}");

            if (userCred != null)
            {
                var userCredentialSpec = new UserCredentialSpecification();
                if (!userCredentialSpec.IsSatisfiedBy(userCred))
                    throw new NullReferenceException("Username/Password cannot be null.");

                var result = PasswordService.HashPassword(userCred.Password);
                userCred.Password = result.HashedPassword;
                userCred.SetKey(user, result.SaltKey);

                user.Credentials = userCred;
            }
        }


        public bool VerifyUserCredentials(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return false;

            var user = _userRepository.GetBy(username);
            if (user == null)
                return false;

            return PasswordService.VerifyPasswords(user.Credentials, password);
        }
    }
}
