using System;
using System.Collections.Generic;
using System.Threading;
using Fishbay.Core;
using Fishbay.Data;

namespace Fishbay.BLL
{
    public class Users : BaseData
    {
        #region Users

        public static User GetUserByEmail(string email)
        {
            User user = null;
            string key = "Users_GetUserByEmail_" + email;

            if (Cache[key] != null)
            {
                user = (User) Cache[key];
            }
            else
            {
                user = DataAccess.Users.GetUserByEmail(email);
                CacheData(key, user);
            }
            return user;
        }

        public static User ValidateUser(string email, string password)
        {
            User user = null;
            string key = "Users_ValidateUser_" + email + "_" + password;

            if (Cache[key] != null)
            {
                user = (User) Cache[key];
            }
            else
            {
                user = DataAccess.Users.ValidateUser(email, password);
                CacheData(key, user);
            }
            return user;
        }

        public static User GetUserByUserId(int userId)
        {
            User user = null;
            string key = "Users_GetUserByUserId_" + userId;

            if (Cache[key] != null)
            {
                user = (User) Cache[key];
            }
            else
            {
                user = DataAccess.Users.GetUserByUserId(userId);
                CacheData(key, user);
            }
            return user;
        }

        

        public static List<User> GetUsersByState(UserState state, Roles role)
        {
            List<User> users = DataAccess.Users.GetUsersByState(state, role);
            return users;
        }

        public static User CreateUser(User user)
        {
            RemoveFromCache("Users_");
            DataAccess.Users.CreateUser(user);
            return new User();
        }

        public static bool UpdateUserState(Guid userUid, UserState prevState, UserState newState)
        {
            RemoveFromCache("Users_");
            return DataAccess.Users.UpdateUserState(userUid, prevState, newState);
        }

        #endregion

        #region Roles

        public static List<Role> GetRoles()
        {
            List<Role> roles = null;
            string key = "Users_GetRoles_";

            if (Cache[key] != null)
            {
                roles = (List<Role>) Cache[key];
            }
            else
            {
                roles = DataAccess.Users.GetRoles();
                CacheData(key, roles);
            }
            return roles;
        }

        #endregion
    }
}