using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalIo.Services.Models.User
{
    public class UserStats
    {
        public int Id { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Top5 { get; set; }
        public int Kills { get; set; }
    }
}
