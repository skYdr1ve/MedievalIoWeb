using Newtonsoft.Json;

namespace MedievalIo.Server.Client.Models
{
    public class StoreItemResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        [JsonProperty(PropertyName = "coins_price  ")]
        public int CoinsPrice { get; set; }
        [JsonProperty(PropertyName = "gems_price  ")]
        public int GemsPrice { get; set; }
        [JsonProperty(PropertyName = "image_id  ")]
        public string ImageId { get; set; }
        [JsonProperty(PropertyName = "on_sale ")]
        public bool OnSale { get; set; }
        [JsonProperty(PropertyName = "sale_coins_price ")]
        public int SaleCoinsPrice { get; set; }
        [JsonProperty(PropertyName = "sale_gems_price ")]
        public int SaleGemsPrice { get; set; }
    }
}
