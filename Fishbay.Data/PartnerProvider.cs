using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fishbay.Core;

namespace Fishbay.Data
{
    public class PartnerProvider : PartnerManager
    {
        public override Partner GetPartnerByPartnerId(int partnerId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Partners_GetPartnerByPartnerId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = partnerId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetPartnerFromReader(reader);
                else
                    return null;
            }
        }

        public override List<Partner> GetPagedPartners(int pageIndex, int pageSize, int sectionId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Partners_GetPagedPartners", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = sectionId;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cn.Open();
                return GetPartnerCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int CountPartners(int sectionId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Partners_CountPartners", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = sectionId;
                cn.Open();
                return (int) ExecuteScalar(cmd);
            }
        }

        public override List<Partner> GetFrontPartners(int count)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Partners_GetFrontPartners", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Count", SqlDbType.Int).Value = count;
                cn.Open();
                return GetPartnerCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int InsertPartner(Partner partner)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Partners_InsertPartner", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = partner.SectionId;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = partner.ItemState;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = partner.Title;
                cmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = partner.UrlLink;
                cmd.Parameters.Add("@TextBody", SqlDbType.NVarChar).Value = partner.TextBody;
                cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = partner.Author;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = partner.Created;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int) cmd.Parameters["@Id"].Value;
            }
        }

        public override bool UpdatePartner(Partner partner)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Partners_UpdatePartner", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = partner.Id;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = partner.SectionId;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = partner.ItemState;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = partner.Title;
                cmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = partner.UrlLink;
                cmd.Parameters.Add("@TextBody", SqlDbType.NVarChar).Value = partner.TextBody;
                cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = partner.Author;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = partner.Created;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}