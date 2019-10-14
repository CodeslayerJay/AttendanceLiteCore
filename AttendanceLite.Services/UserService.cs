using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Exceptions;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using AttendanceLite.Domain.Specifications;
using AttendanceLite.Domain.Interfaces.Services;
using AttendanceLite.Domain.Interfaces;

namespace AttendanceLite.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void RegisterUser(User user)
        {
            if (user == null)
                throw new UserNullException(nameof(RegisterUser));

            var userSpec = new UserSpecification();
            if (!userSpec.IsSatisfiedBy(user))
                throw new Exception("User did not pass validation. One or more arguments is null.");

            _unitOfWork.Users.Add(user);
            _unitOfWork.SaveChanges();

        }

        public void SaveUserCredentials(UserCredential userCred)
        {

            var user = _unitOfWork.Users.GetBy(userCred.UserId);

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

            var user = _unitOfWork.Users.GetBy(username);
            if (user == null)
                return false;

            return PasswordService.VerifyPasswords(user.Credentials, password);
        }

    }
}
