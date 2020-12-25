using Newtonsoft.Json;

namespace MedievalIo.Server.Client.Models
{
    public class UserItemInfoResult
    {
        [JsonProperty(PropertyName = "item_id")]
        public string ItemId { get; set; }
        public bool Equipped { get; set; }
    }
}
