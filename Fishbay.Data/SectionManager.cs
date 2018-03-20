using System;
using System.Collections.Generic;
using System.Data;
using Fishbay.Core;

namespace Fishbay.Data
{
    public abstract class SectionManager: DataAccess
    {
        private static SectionManager _instance;

        public static SectionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SectionProvider();
                }
                return _instance;
            }
        }

        public abstract Section GetSectionBySectionId(int sectionId);
        public abstract List<Section> GetSectionsByParentId(int parentId);
        public abstract List<Section> GetPagedSections(int pageIndex, int pageSize);
        public abstract int CountSections(ItemState itemState);
        public abstract int InsertSection(Section section);
        public abstract bool UpdateSection(Section section);
        protected virtual Section GetSectionFromReader(IDataReader reader)
        {
            Section section = new Section()
            {
                Id = (int)reader["Id"],
                ParentId = (int)reader["ParentId"],
                ChildIndex = (int)reader["ChildIndex"],
                ItemState = (ItemState)reader["ItemState"],
                Name = reader["Name"].ToString()
            };
            return section;
        }

        protected virtual List<Section> GetSectionCollectionFromReader(IDataReader reader)
        {
            List<Section> items = new List<Section>();
            while (reader.Read())
                items.Add(GetSectionFromReader(reader));
            return items;
        }
    }
}