using System;
using Newtonsoft.Json;

namespace Fishbay.Core
{
    public class Partner
    {
        public int Id { get; set; }
        public ItemState ItemState { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Info { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string UrlLink { get; set; }
        public string Logo { get; set; }
        public DateTime Created { get; set; }
    }
}