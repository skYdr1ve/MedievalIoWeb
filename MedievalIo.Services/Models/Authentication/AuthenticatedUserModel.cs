using System;
using System.Collections.Generic;
using System.Text;

namespace MedievalIo.Services.Models.Authentication
{
    public class AuthenticatedUserModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
