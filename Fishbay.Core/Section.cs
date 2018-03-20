using Newtonsoft.Json;

namespace Fishbay.Core
{
    public class Section
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildIndex { get; set; }
        [JsonIgnore]
        public ItemState ItemState { get; set; }
        public string Name { get; set; }
    }
}