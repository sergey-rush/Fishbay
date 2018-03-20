using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fishbay.Core;

namespace Fishbay.Data
{
    public class SectionProvider : SectionManager
    {
        public override Section GetSectionBySectionId(int sectionId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sections_GetSectionBySectionId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = sectionId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetSectionFromReader(reader);
                else
                    return null;
            }
        }

        public override List<Section> GetSectionsByParentId(int parentId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sections_GetSectionsByParentId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParentId", SqlDbType.Int).Value = parentId;
                cn.Open();
                return GetSectionCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override List<Section> GetPagedSections(int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sections_GetPagedSections", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cn.Open();
                return GetSectionCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int CountSections(ItemState itemState)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sections_CountSections", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = itemState;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        public override int InsertSection(Section section)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sections_InsertSection", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = section.Id;
                cmd.Parameters.Add("@ParentId", SqlDbType.Int).Value = section.ParentId;
                cmd.Parameters.Add("@ChildIndex", SqlDbType.Int).Value = section.ChildIndex;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = section.ItemState;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@Id"].Value;
            }
        }

        public override bool UpdateSection(Section section)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Sections_UpdateSection", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = section.Id;
                cmd.Parameters.Add("@ParentId", SqlDbType.Int).Value = section.ParentId;
                cmd.Parameters.Add("@ChildIndex", SqlDbType.Int).Value = section.ChildIndex;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = section.ItemState;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}