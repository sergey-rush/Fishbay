using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Fishbay.Core;

namespace Fishbay.Data
{
    public class PriceItemProvider : PriceItemManager
    {
        public override PriceItem GetPriceItemByPriceItemId(int priceItemId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PriceItems_GetPriceItemByPriceItemId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PriceItemId", SqlDbType.Int).Value = priceItemId;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetPriceItemFromReader(reader);
                else
                    return null;
            }
        }

        public override List<PriceItem> GetPagedPriceItems(int pageIndex, int pageSize, int sectionId)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PriceItems_GetPagedPriceItems", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cn.Open();
                return GetPriceItemCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int CountPriceItems(ItemState itemState)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PriceItems_CountPriceItems", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = itemState;
                cn.Open();
                return (int) ExecuteScalar(cmd);
            }
        }

        public override List<PriceItem> GetFrontPriceItems(int count)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PriceItems_GetFrontPriceItems", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Count", SqlDbType.Int).Value = count;
                cn.Open();
                return GetPriceItemCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public override int InsertPriceItem(PriceItem priceItem)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PriceItems_InsertPriceItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = priceItem.PartnerId;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = priceItem.SectionId;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = priceItem.ItemState;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = priceItem.Name;
                cmd.Parameters.Add("@UnitType", SqlDbType.NVarChar).Value = priceItem.UnitType;
                cmd.Parameters.Add("@RetailPrice", SqlDbType.Money).Value = priceItem.RetailPrice;
                cmd.Parameters.Add("@SmallWholeSalePrice", SqlDbType.Money).Value = priceItem.SmallWholeSalePrice;
                cmd.Parameters.Add("@LargeWholeSalePrice", SqlDbType.Money).Value = priceItem.LargeWholeSalePrice;
                cmd.Parameters.Add("@PriceDate", SqlDbType.DateTime).Value = priceItem.PriceDate;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = priceItem.Created;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int) cmd.Parameters["@Id"].Value;
            }
        }

        public override bool UpdatePriceItem(PriceItem priceItem)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PriceItems_UpdatePriceItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = priceItem.Id;
                cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = priceItem.PartnerId;
                cmd.Parameters.Add("@SectionId", SqlDbType.Int).Value = priceItem.SectionId;
                cmd.Parameters.Add("@ItemState", SqlDbType.Int).Value = priceItem.ItemState;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = priceItem.Name;
                cmd.Parameters.Add("@UnitType", SqlDbType.NVarChar).Value = priceItem.UnitType;
                cmd.Parameters.Add("@RetailPrice", SqlDbType.Money).Value = priceItem.RetailPrice;
                cmd.Parameters.Add("@SmallWholeSalePrice", SqlDbType.Money).Value = priceItem.SmallWholeSalePrice;
                cmd.Parameters.Add("@LargeWholeSalePrice", SqlDbType.Money).Value = priceItem.LargeWholeSalePrice;
                cmd.Parameters.Add("@PriceDate", SqlDbType.DateTime).Value = priceItem.PriceDate;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = priceItem.Created;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }
    }
}