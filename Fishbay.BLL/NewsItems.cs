using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fishbay.Core;
using Fishbay.Data;

namespace Fishbay.BLL
{
    public class NewsItems: BaseData
    {
        public static NewsItem GetNewsItemByNewsItemId(int newsItemId)
        {
            NewsItem newsItem = null;
            string key = "NewsItems_GetNewsItemByNewsItemId_" + newsItemId;

            if (Cache[key] != null)
            {
                newsItem = (NewsItem)Cache[key];
            }
            else
            {
                newsItem = DataAccess.NewsItems.GetNewsItemByNewsItemId(newsItemId);
                CacheData(key, newsItem);
            }
            return newsItem;
        }

        public static List<NewsItem> GetPagedNewsItems(int startRowIndex, int maximumRows, int sectionId)
        {
            List<NewsItem> cats = null;
            string key = "NewsItems_GetPagedNewsItems_" + startRowIndex + "_" + maximumRows + "_" + sectionId;

            if (Cache[key] != null)
            {
                cats = (List<NewsItem>)Cache[key];
            }
            else
            {
                cats = DataAccess.NewsItems.GetPagedNewsItems(GetPageIndex(startRowIndex, maximumRows), maximumRows, sectionId);
                CacheData(key, cats);
            }
            return cats;
        }

        public static int CountNewsItems(int sectionId)
        {
            int itemCount = 0;
            string key = "NewsItems_CountNewsItems_" + sectionId;
            if (Cache[key] != null)
            {
                itemCount = (int)Cache[key];
            }
            else
            {
                itemCount = DataAccess.NewsItems.CountNewsItems(sectionId);
                CacheData(key, itemCount);
            }
            return itemCount;
        }
    }
}
