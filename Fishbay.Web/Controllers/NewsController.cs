using System.Web.Mvc;
using Fishbay.Web.Models;

namespace Fishbay.Web.Controllers
{
    public class NewsController: Controller
    {
        public ActionResult Index()
        {
            DataModel dataModel = new DataModel();
            return View(dataModel);
        }
    }
}