using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalIo.Server.Client.Models
{
    public class StoreItemResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int CoinsPrice { get; set; }
        public int GemsPrice { get; set; }
        public string ImageId { get; set; }
    }
}
