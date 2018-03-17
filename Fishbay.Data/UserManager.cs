using System;
using System.Collections.Generic;
using System.Data;
using Fishbay.Core;

namespace Fishbay.Data
{
    public abstract class UserManager: DataAccess
    {
        private static UserManager _instance;

        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserProvider();
                }
                return _instance;
            }
        }

        #region Users

        public abstract User GetUserByEmail(string email);
        public abstract User ValidateUser(string email, string password);
        public abstract User GetUserByUserId(int userId);
        public abstract List<User> GetUsersByState(UserState state, Roles role);
        public abstract int CreateUser(User user);
        public abstract bool UpdateUserState(Guid userUid, UserState prevState, UserState newState);
        protected virtual User GetUserFromReader(IDataReader reader)
        {
            User user = new User()
            {
                Id = (int)reader["id"],
                FullName = reader["name"].ToString(),
                Email = reader["email"].ToString(),
                Password = reader["password"].ToString(),
                UserUid = (Guid)reader["user_uid"],
                Role = (Roles)reader["role_id"],
                UserState = (UserState)reader["state_id"],
                AccountState = (AccountState)reader["account_state"],
                Created = (DateTime)reader["created"]
            };

            if (reader["phone"] != DBNull.Value)
            {
                user.Phone = reader["phone"].ToString();
            }

            if (reader["failed_count"] != DBNull.Value)
            {
                user.FailedAttemptCount = (int)reader["failed_count"];
            }

            if (reader["last_login"] != DBNull.Value)
            {
                user.LastLoginDate = (DateTime) reader["last_login"];
            }

            return user;
        }
       
        protected virtual List<User> GetUserCollectionFromReader(IDataReader reader)
        {
            List<User> items = new List<User>();
            while (reader.Read())
                items.Add(GetUserFromReader(reader));
            return items;
        }

        #endregion

        #region Roles

        public abstract List<Role> GetRoles();

        protected virtual Role GetRoleFromReader(IDataReader reader)
        {
            Role user = new Role()
            {
                Id = (int)reader["id"],
                Name = reader["name"].ToString(),
                Alias = reader["alias"].ToString()
            };

            return user;
        }

        protected virtual List<Role> GetRoleCollectionFromReader(IDataReader reader)
        {
            List<Role> items = new List<Role>();
            while (reader.Read())
                items.Add(GetRoleFromReader(reader));
            return items;
        }


        #endregion

    }
}