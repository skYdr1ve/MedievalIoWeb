using Newtonsoft.Json;

namespace MedievalIo.Server.Client.Models
{
    public class AuthenticateResult
    {
        public string Token { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
