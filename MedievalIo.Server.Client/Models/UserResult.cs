using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalIo.Server.Client.Models
{
    public class UserResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Coins { get; set; }
        public int? Gems { get; set; }
        public List<StoreItemResult> Items { get; set; }
        public UserStatsResult Stats { get; set; }
    }
}
