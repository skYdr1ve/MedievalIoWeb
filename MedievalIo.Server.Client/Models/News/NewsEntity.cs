using System;
using Newtonsoft.Json;

namespace MedievalIo.Server.Client.Models.News
{
    public class NewsEntity
    {
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "image_link")]
        public string ImageLink { get; set; }
    }
}
