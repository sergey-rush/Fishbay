using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using Fishbay.Core;
using Fishbay.Crypto;

namespace Fishbay.BLL
{
    public class Membership
    {
        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <param name="phone"></param>
        /// <param name="role"></param>
        /// <returns>User</returns>
        public static User CreateUser(string email, string password, string fullName, string phone, Roles role)
        {
            BaseEncryptor cryptoProvider = CryptoManager.GetEncryptor(Encryptor.Hash);
            User user = new User();
            user.Email = email;
            user.FullName = fullName;
            user.Phone = phone;
            user.Role = role;
            user.AccountState = AccountState.Enabled;
            user.Password = cryptoProvider.Encrypt(password);
            user = Users.CreateUser(user);
            return user;
        }

        

        public static bool ValidateUser(string username, string password)
        {
            bool result = false;
            BaseEncryptor cryptoProvider = CryptoManager.GetEncryptor(Encryptor.Hash);
            string encryptedPassword = cryptoProvider.Encrypt(password);
            User user = Users.ValidateUser(username, encryptedPassword);
            if (user != null)
            {
                result = true;
            }
            return result;
        }
    }
}