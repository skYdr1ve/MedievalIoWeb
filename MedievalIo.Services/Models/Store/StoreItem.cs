using System;

namespace MedievalIo.Services.Models.Store
{
    public class StoreItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int CoinsPrice { get; set; }
        public int GemsPrice { get; set; }
        public string ImageId { get; set; }
    }
}
