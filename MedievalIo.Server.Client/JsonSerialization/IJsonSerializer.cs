using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedievalIo.Server.Client.JsonSerialization
{
    public interface IJsonSerializer
    {
        HttpContent SerializeAsync(object requestBody);

        Task<T> DeserializeAsync<T>(HttpContent responseContent);
    }
}
