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
    public class Partners : BaseData
    {
        public static Partner GetPartnerByPartnerId(int partnerId)
        {
            Partner partner = null;
            string key = "Partners_GetPartnerByPartnerId_" + partnerId;

            if (Cache[key] != null)
            {
                partner = (Partner) Cache[key];
            }
            else
            {
                partner = DataAccess.Partners.GetPartnerByPartnerId(partnerId);
                CacheData(key, partner);
            }
            return partner;
        }

        public static List<Partner> GetPagedPartners(int pageIndex, int pageSize, int sectionId)
        {
            List<Partner> cats = null;
            string key = "Partners_GetPagedPartners_" + pageIndex + "_" + pageSize + "_" + sectionId;

            if (Cache[key] != null)
            {
                cats = (List<Partner>) Cache[key];
            }
            else
            {
                cats = DataAccess.Partners.GetPagedPartners(pageIndex, pageSize, sectionId);
                CacheData(key, cats);
            }
            return cats;
        }
        
        public static int CountPartners(ItemState itemState)
        {
            int itemCount = 0;
            string key = "Partners_CountPartners_" + itemState;
            if (Cache[key] != null)
            {
                itemCount = (int) Cache[key];
            }
            else
            {
                itemCount = DataAccess.Partners.CountPartners(itemState);
                CacheData(key, itemCount);
            }
            return itemCount;
        }
    }
}
