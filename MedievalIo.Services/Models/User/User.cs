using System;
using System.Collections.Generic;
using MedievalIo.Services.Models.Store;

namespace MedievalIo.Services.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Coins { get; set; }
        public int? Gems { get; set; }
        public List<StoreItem> Items { get; set; }
        public UserStats Stats { get; set; }
    }
}
