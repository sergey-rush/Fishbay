using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fishbay.Core;

namespace Fishbay.Data
{
    public class UserProvider : UserManager
    {
        #region Users

        public override User GetUserByEmail(string email)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetUserByUserId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = email;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetUserFromReader(reader);
                else
                    return null;
            }
        }

        public override User ValidateUser(string email, string password)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetUserByUserId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = email;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetUserFromReader(reader);
                else
                    return null;
            }
        }

        public override User GetUserByUserId(int userId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetUserByUserId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetUserFromReader(reader);
                else
                    return null;
            }
        }

        public override List<User> GetUsersByState(UserState state, Roles role)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetPagedUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = state;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = role;
                cn.Open();
                return GetUserCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int CreateUser(User user)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_InsertUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = user.Id;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = user.Created;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@Id"].Value;
            }
        }
        public override bool UpdateUserState(Guid userUid, UserState prevState, UserState newState)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_UpdateUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = prevState;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = newState;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        #endregion

        #region Roles

        public override List<Role> GetRoles()
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Users_GetPagedUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetRoleCollectionFromReader(ExecuteReader(cmd));
            }
        }

        #endregion
    }
}