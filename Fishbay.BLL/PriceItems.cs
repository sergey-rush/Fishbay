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
    public class PriceItems : BaseData
    {
        public static PriceItem GetPriceItemByPriceItemId(int priceItemId)
        {
            PriceItem priceItem = null;
            string key = "PriceItems_GetPriceItemByPriceItemId_" + priceItemId;

            if (Cache[key] != null)
            {
                priceItem = (PriceItem) Cache[key];
            }
            else
            {
                priceItem = DataAccess.PriceItems.GetPriceItemByPriceItemId(priceItemId);
                CacheData(key, priceItem);
            }
            return priceItem;
        }

        public static List<PriceItem> GetPagedPriceItems(int pageIndex, int pageSize, int sectionId)
        {
            List<PriceItem> cats = null;
            string key = "PriceItems_GetPagedPriceItems_" + pageIndex + "_" + pageSize + "_" + sectionId;

            if (Cache[key] != null)
            {
                cats = (List<PriceItem>) Cache[key];
            }
            else
            {
                cats = DataAccess.PriceItems.GetPagedPriceItems(pageIndex, pageSize, sectionId);
                CacheData(key, cats);
            }
            return cats;
        }
        
        public static int CountPriceItems(ItemState itemState)
        {
            int itemCount = 0;
            string key = "PriceItems_CountPriceItems_" + itemState;
            if (Cache[key] != null)
            {
                itemCount = (int) Cache[key];
            }
            else
            {
                itemCount = DataAccess.PriceItems.CountPriceItems(itemState);
                CacheData(key, itemCount);
            }
            return itemCount;
        }
    }
}
