using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MedievalIo.Server.Client.JsonSerialization
{
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        private const string JsonMimeType = "application/json";

        public async Task<T> DeserializeAsync<T>(HttpContent responseContent)
        {
            var responseContentString = await responseContent.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContentString);
        }

        public HttpContent SerializeAsync(object requestBody)
        {
            return new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, JsonMimeType);
        }
    }
}
