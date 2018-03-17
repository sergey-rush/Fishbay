﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fishbay.Core;

namespace Fishbay.Data
{
    public class NewsProvider : NewsManager
    {
        public override NewsItem GetNewsItemByNewsItemId(int newsItemId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("NewsItems_GetNewsItemByNewsItemId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NewsItemId", SqlDbType.Int).Value = newsItemId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetNewsItemFromReader(reader);
                else
                    return null;
            }
        }

        public override List<NewsItem> GetPagedNewsItems(int startRowIndex, int maximumRows, int sectionId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("NewsItems_GetPagedNewsItems", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = sectionId;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = startRowIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = maximumRows;
                cn.Open();
                return GetNewsItemCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int CountNewsItems(int sectionId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("NewsItems_CountNewsItems", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = sectionId;
                cn.Open();
                return (int) ExecuteScalar(cmd);
            }
        }

        public override int InsertNewsItem(NewsItem newsItem)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("NewsItems_InsertNewsItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = newsItem.SectionId;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = newsItem.ItemState;
                cmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = newsItem.UrlLink;
                cmd.Parameters.Add("@TextBody", SqlDbType.Text).Value = newsItem.TextBody;
                cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = newsItem.Author;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = newsItem.Created;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int) cmd.Parameters["@Id"].Value;
            }
        }

        public override bool UpdateNewsItem(NewsItem newsItem)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("NewsItems_UpdateNewsItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = newsItem.Id;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = newsItem.SectionId;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = newsItem.ItemState;
                cmd.Parameters.Add("@UrlLink", SqlDbType.NVarChar).Value = newsItem.UrlLink;
                cmd.Parameters.Add("@TextBody", SqlDbType.Text).Value = newsItem.TextBody;
                cmd.Parameters.Add("@Author", SqlDbType.NVarChar).Value = newsItem.Author;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = newsItem.Created;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}