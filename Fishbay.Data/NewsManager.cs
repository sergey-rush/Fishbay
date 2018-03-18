using System;
using System.Collections.Generic;
using System.Data;
using Fishbay.Core;

namespace Fishbay.Data
{
    public abstract class NewsManager: DataAccess
    {
        private static NewsManager instance;

        public static NewsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NewsProvider();
                }
                return instance;
            }
        }

        public abstract NewsItem GetNewsItemByNewsItemId(int newsItemId);
        public abstract List<NewsItem> GetPagedNewsItems(int pageIndex, int pageSize, int sectionId);
        public abstract List<NewsItem> GetFrontNewsItems(int count);
        public abstract int CountNewsItems(int sectionId);
        public abstract int InsertNewsItem(NewsItem newsItem);
        public abstract bool UpdateNewsItem(NewsItem newsItem);
        public abstract bool DeleteNewsItemByNewsItemId(int newsItemId);
        protected virtual NewsItem GetNewsItemFromReader(IDataReader reader)
        {
            NewsItem newsItem = new NewsItem()
            {
                Id = (int) reader["Id"],
                SectionId = (int) reader["SectionId"],
                ItemState = (ItemState) reader["ItemState"],
                UrlLink = reader["UrlLink"].ToString(),
                Title = reader["Title"].ToString(),
                SubTitle = reader["SubTitle"].ToString(),
                TextBody = reader["TextBody"].ToString(),
                Author = reader["Author"].ToString(),
                Created = (DateTime) reader["Created"]
            };

            if (reader["ImageUrl"] != DBNull.Value)
            {
                newsItem.ImageUrl = reader["ImageUrl"].ToString();
            }

            return newsItem;
        }

        /// <summary>
        /// Returns a collection of NewsItem objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<NewsItem> GetNewsItemCollectionFromReader(IDataReader reader)
        {
            List<NewsItem> m = new List<NewsItem>();
            while (reader.Read())
                m.Add(GetNewsItemFromReader(reader));
            return m;
        }
    }
}