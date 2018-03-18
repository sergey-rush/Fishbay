using System;
using Newtonsoft.Json;

namespace Fishbay.Core
{
    public class Partner
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public ItemState ItemState { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string UrlLink { get; set; }
        public string TextBody { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; }
    }
}