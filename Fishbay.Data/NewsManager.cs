﻿using System;
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
        public abstract List<NewsItem> GetPagedNewsItems(int startRowIndex, int maximumRows, int memberId);
        public abstract int CountNewsItems(int memberId);
        public abstract int InsertNewsItem(NewsItem newsItem);
        public abstract bool UpdateNewsItem(NewsItem newsItem);
        protected virtual NewsItem GetNewsItemFromReader(IDataReader reader)
        {
            NewsItem newsItem = new NewsItem()
            {
                Id = (int)reader["Id"],
                SectionId = (int)reader["SectionId"],
                ItemState = (ItemState)reader["ItemState"],
                UrlLink = reader["UrlLink"].ToString(),
                Title = reader["Title"].ToString(),
                TextBody = reader["TextBody"].ToString(),
                Author = reader["Author"].ToString(),
                Created = (DateTime)reader["Created"]
            };
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