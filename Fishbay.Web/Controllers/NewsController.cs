using System.Web.Mvc;
using Fishbay.BLL;
using Fishbay.Web.Models;

namespace Fishbay.Web.Controllers
{
    public class NewsController: Controller
    {
        public ActionResult Index()
        {
            //NewsItems.ReceiveNews();
            DataModel dataModel = new DataModel();
            dataModel.NewsItems = NewsItems.GetPagedNewsItems(0, 100, 0);
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