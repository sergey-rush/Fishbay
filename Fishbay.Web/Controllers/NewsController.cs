using System.Collections.Generic;
using System.Web.Mvc;
using Fishbay.BLL;
using Fishbay.Core;
using Fishbay.Web.Models;

namespace Fishbay.Web.Controllers
{
    public class NewsController: Controller
    {
        public ActionResult Index()
        {
            //NewsItems.ReceiveNews();
            DataModel dataModel = new DataModel();
            List<NewsItem> newsItems = NewsItems.GetPagedNewsItems(0, 100, 0);
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

        public ActionResult Loader()
        {
            DataModel dataModel = new DataModel();
            return View(dataModel);
        }


    }
}