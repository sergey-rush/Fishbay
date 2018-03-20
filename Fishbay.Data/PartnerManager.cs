using System;
using System.Collections.Generic;
using System.Data;
using Fishbay.Core;

namespace Fishbay.Data
{
    public abstract class PartnerManager: DataAccess
    {
        private static PartnerManager instance;

        public static PartnerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PartnerProvider();
                }
                return instance;
            }
        }

        public abstract Partner GetPartnerByPartnerId(int partnerId);
        public abstract List<Partner> GetPagedPartners(int pageIndex, int pageSize, int sectionId);
        public abstract List<Partner> GetFrontPartners(int count);
        public abstract int CountPartners(ItemState itemState);
        public abstract int InsertPartner(Partner partner);
        public abstract bool UpdatePartner(Partner partner);

        protected virtual Partner GetPartnerFromReader(IDataReader reader)
        {
            Partner partner = new Partner()
            {
                Id = (int) reader["Id"],
                ItemState = (ItemState) reader["ItemState"],
                Title = reader["Title"].ToString(),
                About = reader["About"].ToString(),
                Info = reader["Info"].ToString(),
                Contact = reader["Contact"].ToString(),
                Address = reader["Address"].ToString(),
                UrlLink = reader["UrlLink"].ToString(),
                Created = (DateTime) reader["Created"]
            };

            //if (reader["ImageUrl"] != DBNull.Value)
            //{
            //    partner.ImageUrl = reader["ImageUrl"].ToString();
            //}

            return partner;
        }

        /// <summary>
        /// Returns a collection of Partner objects with the data read from the input DataReader
        /// </summary>
        protected virtual List<Partner> GetPartnerCollectionFromReader(IDataReader reader)
        {
            List<Partner> m = new List<Partner>();
            while (reader.Read())
                m.Add(GetPartnerFromReader(reader));
            return m;
        }
    }
}