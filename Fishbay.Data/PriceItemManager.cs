using System;
using System.Collections.Generic;
using System.Data;
using Fishbay.Core;

namespace Fishbay.Data
{
    public abstract class PriceItemManager: DataAccess
    {
        private static PriceItemManager instance;

        public static PriceItemManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PriceItemProvider();
                }
                return instance;
            }
        }

        public abstract PriceItem GetPriceItemByPriceItemId(int priceItemId);
        public abstract List<PriceItem> GetPagedPriceItems(int pageIndex, int pageSize, int sectionId);
        public abstract List<PriceItem> GetFrontPriceItems(int count);
        public abstract int CountPriceItems(ItemState itemState);
        public abstract int InsertPriceItem(PriceItem priceItem);
        public abstract bool UpdatePriceItem(PriceItem priceItem);

        protected virtual PriceItem GetPriceItemFromReader(IDataReader reader)
        {
            PriceItem priceItem = new PriceItem()
            {
                Id = (int) reader["Id"],
                PartnerId = (int)reader["PartnerId"],
                SectionId = (int)reader["SectionId"],
                ItemState = (ItemState) reader["ItemState"],
                Name = reader["Name"].ToString(),
                Created = (DateTime) reader["Created"]
            };

            if (reader["UnitType"] != DBNull.Value)
            {
                priceItem.UnitType = reader["UnitType"].ToString();
            }

            if (reader["RetailPrice"] != DBNull.Value)
            {
                priceItem.RetailPrice = (decimal)reader["RetailPrice"];
            }

            if (reader["SmallWholeSalePrice"] != DBNull.Value)
            {
                priceItem.RetailPrice = (decimal)reader["SmallWholeSalePrice"];
            }

            if (reader["LargeWholeSalePrice"] != DBNull.Value)
            {
                priceItem.RetailPrice = (decimal)reader["LargeWholeSalePrice"];
            }

            return priceItem;
        }

        /// <summary>
        /// Returns a collection of PriceItem objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<PriceItem> GetPriceItemCollectionFromReader(IDataReader reader)
        {
            List<PriceItem> m = new List<PriceItem>();
            while (reader.Read())
                m.Add(GetPriceItemFromReader(reader));
            return m;
        }
    }
}