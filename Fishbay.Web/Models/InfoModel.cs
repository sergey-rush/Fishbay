using System;
using System.Collections.Generic;
using Fishbay.Core;
using Newtonsoft.Json;

namespace Fishbay.Web.Models
{
    public class InfoModel
    {
        public InfoType InfoType { get; set; }
        public UserState UserState { get; set; }
        public ItemState PrevState { get; set; }
        public ItemState NewState { get; set; }
        public Guid UserUid { get; set; }
        public Guid PickUid { get; set; }
        public Guid PickItemUid { get; set; }
    }
}