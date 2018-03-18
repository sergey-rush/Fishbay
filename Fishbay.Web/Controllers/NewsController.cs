using System.Collections.Generic;
using System.Web.Mvc;
using Fishbay.BLL;
using Fishbay.Core;
using Fishbay.Web.Models;

namespace Fishbay.Web.Controllers
{
    public class NewsController: Controller
    {
        public ActionResult NewsList(int? page)
        {
            int pageNum = 1;
            if (page != null)
            {
                pageNum = page.Value;
            }
            DataModel dataModel = new DataModel();
            
            int pageSize = 10;
            
            dataModel.NewsItems = NewsItems.GetPagedNewsItems(pageNum, pageSize, 0);
            int itemsCount = NewsItems.CountNewsItems(0);

            dataModel.Pager = new Pager(itemsCount, pageNum, pageSize);
            return View(dataModel);
        }

        public ActionResult Index()
        {
            DataModel dataModel = new DataModel();
            List<NewsItem> newsItems = NewsItems.GetFrontNewsItems(30);
            dataModel.FirstNewsItem = newsItems[0];
            dataModel.SecondNewsItem = newsItems[1];
            dataModel.ThirdNewsItem = newsItems[2];
            dataModel.FourthNewsItem = newsItems[3];
            dataModel.FifthNewsItem = newsItems[4];
            dataModel.NewsItems = new List<NewsItem>();
            foreach (NewsItem newsItem in newsItems)
            {
                if (newsItem.ItemState == ItemState.Enabled)
                {
                    dataModel.NewsItems.Add(newsItem);
                }
            }

            return View(dataModel);
        }

        public ActionResult NewsItem(int id)
        {
            DataModel dataModel = new DataModel();
            dataModel.SelectedNewsItem = NewsItems.GetNewsItemByNewsItemId(id);
            return View(dataModel);
        }
    }
}