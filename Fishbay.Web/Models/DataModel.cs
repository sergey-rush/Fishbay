using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Fishbay.Core;

namespace Fishbay.Web.Models
{
    public class DataModel
    {
        public IList<SelectListItem> Items { get; set; }
        public SelectListItem SelectedItem { get; set; }
        public List<NewsItem> NewsItems { get; set; }
        public NewsItem SelectedNewsItem { get; set; }

        public string Query { get; set; }
    }
}