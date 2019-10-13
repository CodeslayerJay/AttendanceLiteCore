using AttendanceLite.Domain.Entities;
using AttendanceLite.Domain.Interfaces.Services;
using AttendanceLite.Domain.Types;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AttendanceLite.Services
{
    public static class PasswordService
    {
        public static HashResult HashPassword(string password, byte[] salt = null)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Password cannot be null.");

            if(salt == null)
            {
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }
            

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return new HashResult { HashedPassword = hashed, SaltKey = salt };
        }

        public static bool VerifyPasswords(UserCredential userCreds, string password)
        {
            var result = HashPassword(password, userCreds.GetKey());
            return  result.HashedPassword == userCreds.Password;
        }
    }
}
