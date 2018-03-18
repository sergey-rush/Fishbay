using System.Collections.Generic;
using System.Web.Mvc;
using Fishbay.BLL;
using Fishbay.Core;
using Fishbay.Web.Models;

namespace Fishbay.Web.Controllers
{
    public class PartnersController: Controller
    {
        public ActionResult Index()
        {
            DataModel dataModel = new DataModel();
            return View(dataModel);
        }
    }
}