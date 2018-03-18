using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Fishbay.Core;
using Fishbay.Data;

namespace Fishbay.BLL
{
    public class NewsItems : BaseData
    {
        public static NewsItem GetNewsItemByNewsItemId(int newsItemId)
        {
            NewsItem newsItem = null;
            string key = "NewsItems_GetNewsItemByNewsItemId_" + newsItemId;

            if (Cache[key] != null)
            {
                newsItem = (NewsItem) Cache[key];
            }
            else
            {
                newsItem = DataAccess.NewsItems.GetNewsItemByNewsItemId(newsItemId);
                CacheData(key, newsItem);
            }
            return newsItem;
        }

        public static List<NewsItem> GetPagedNewsItems(int pageIndex, int pageSize, int sectionId)
        {
            List<NewsItem> cats = null;
            string key = "NewsItems_GetPagedNewsItems_" + pageIndex + "_" + pageSize + "_" + sectionId;

            if (Cache[key] != null)
            {
                cats = (List<NewsItem>) Cache[key];
            }
            else
            {
                cats = DataAccess.NewsItems.GetPagedNewsItems(pageIndex, pageSize, sectionId);
                CacheData(key, cats);
            }
            return cats;
        }

        public static List<NewsItem> GetFrontNewsItems(int count)
        {
            List<NewsItem> cats = null;
            string key = "NewsItems_GetFrontNewsItems_" + count;

            if (Cache[key] != null)
            {
                cats = (List<NewsItem>)Cache[key];
            }
            else
            {
                cats = DataAccess.NewsItems.GetFrontNewsItems(count);
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
                itemCount = (int) Cache[key];
            }
            else
            {
                itemCount = DataAccess.NewsItems.CountNewsItems(sectionId);
                CacheData(key, itemCount);
            }
            return itemCount;
        }

        public static List<NewsItem> ReceiveNews()
        {
            List<NewsItem> newsItems = new List<NewsItem>();
            //string url = "http://fish.gov.ru/press-tsentr/novosti?format=feed&type=rss";
            //string url = "http://fish.gov.ru/press-tsentr/anonsy?format=feed&type=rss";
            //string url = "http://fish.gov.ru/press-tsentr/obzor-smi?format=feed&type=rss";
            //string url = "http://fish.gov.ru/territorialnye-upravleniya?format=feed&type=rss";
            string url = "";
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response;
            Stream stream = null;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
                stream = response.GetResponseStream();
            }
            catch
            {
                return null;
            }

            newsItems = ParseNews(stream);

            return newsItems;
        }

        private static List<NewsItem> ParseNews(Stream stream)
        {
            XElement projects = XElement.Load(stream);
            var elements = from e in projects.Descendants("item") select e;
            List<NewsItem> newsItems =
                elements.Select(
                    e =>
                        new NewsItem
                        {
                            Title = e.Element("title").Value,
                            UrlLink = e.Element("link").Value,
                            Created = Convert.ToDateTime(e.Element("pubDate").Value),
                            TextBody = e.Element("description").Value,
                            Author = e.Element("author").Value
                        }).ToList();

            foreach (NewsItem newsItem in newsItems)
            {
                newsItem.SectionId = 4;
                DataAccess.NewsItems.InsertNewsItem(newsItem);
            }


            return newsItems;
        }
    }
}
