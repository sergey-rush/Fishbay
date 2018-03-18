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
        public NewsItem FirstNewsItem { get; set; }
        public NewsItem SecondNewsItem { get; set; }
        public NewsItem ThirdNewsItem { get; set; }
        public NewsItem FourthNewsItem { get; set; }
        public NewsItem FifthNewsItem { get; set; }
        public Pager Pager { get; set; }
        public string Query { get; set; }
    }
}