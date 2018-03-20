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

        public ActionResult Partner(int id)
        {
            DataModel dataModel = new DataModel();
            dataModel.SelectedPartner = Partners.GetPartnerByPartnerId(id);
            return View(dataModel);
        }
    }
}