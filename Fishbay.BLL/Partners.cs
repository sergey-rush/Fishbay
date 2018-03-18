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

        public static List<Partner> GetFrontPartners(int count)
        {
            List<Partner> cats = null;
            string key = "Partners_GetFrontPartners_" + count;

            if (Cache[key] != null)
            {
                cats = (List<Partner>)Cache[key];
            }
            else
            {
                cats = DataAccess.Partners.GetFrontPartners(count);
                CacheData(key, cats);
            }
            return cats;
        }

        public static int CountPartners(int sectionId)
        {
            int itemCount = 0;
            string key = "Partners_CountPartners_" + sectionId;
            if (Cache[key] != null)
            {
                itemCount = (int) Cache[key];
            }
            else
            {
                itemCount = DataAccess.Partners.CountPartners(sectionId);
                CacheData(key, itemCount);
            }
            return itemCount;
        }

        public static List<Partner> ReceivePartner()
        {
            List<Partner> partners = new List<Partner>();
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

            partners = ParsePartner(stream);

            return partners;
        }

        private static List<Partner> ParsePartner(Stream stream)
        {
            XElement projects = XElement.Load(stream);
            var elements = from e in projects.Descendants("item") select e;
            List<Partner> partners =
                elements.Select(
                    e =>
                        new Partner
                        {
                            Title = e.Element("title").Value,
                            UrlLink = e.Element("link").Value,
                            Created = Convert.ToDateTime(e.Element("pubDate").Value),
                            TextBody = e.Element("description").Value,
                            Author = e.Element("author").Value
                        }).ToList();

            foreach (Partner partner in partners)
            {
                partner.SectionId = 4;
                DataAccess.Partners.InsertPartner(partner);
            }


            return partners;
        }
    }
}
