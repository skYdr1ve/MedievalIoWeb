using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using MedievalIo.Server.Client.JsonSerialization;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client
{
    public abstract class BaseClient
    {
        private const string AuthenticationHeaderName = "Bearer";

        private static readonly ConcurrentDictionary<string, HttpClient> _httpClientsCache = new ConcurrentDictionary<string, HttpClient>();

        private readonly IJsonSerializer _jsonSerializer;

        protected BaseClient()
        {
            _jsonSerializer = new NewtonsoftJsonSerializer();
        }

        protected async Task<T> SendRequestAsync<T>(ApiRequestModel apiRequestModel, string requestUrl, object requestBody)
        {
            var client = GetOrCreateHttpClient(apiRequestModel.BaseUrl);

            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = _jsonSerializer.SerializeAsync(requestBody)
            };

            request.Headers.Add(AuthenticationHeaderName, apiRequestModel.Bearer);

            return await SendRequestAsync<T>(client, request);
        }

        protected async Task<T> SendPutRequestAsync<T>(ApiRequestModel apiRequestModel, string requestUrl, object requestBody)
        {
            var client = GetOrCreateHttpClient(apiRequestModel.BaseUrl);

            var request = new HttpRequestMessage(HttpMethod.Put, requestUrl)
            {
                Content = _jsonSerializer.SerializeAsync(requestBody)
            };

            request.Headers.Add(AuthenticationHeaderName, apiRequestModel.Bearer);

            return await SendRequestAsync<T>(client, request);
        }

        protected async Task<T> SendGetRequestAsync<T>(ApiRequestModel apiRequestModel, string requestUrl, object requestBody)
        {
            var client = GetOrCreateHttpClient(apiRequestModel.BaseUrl);

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl)
            {
                Content = _jsonSerializer.SerializeAsync(requestBody)
            };

            request.Headers.Add(AuthenticationHeaderName, apiRequestModel.Bearer);

            return await SendRequestAsync<T>(client, request);
        }

        protected async Task<T> SendRequestAsync<T>(HttpClient httpClient, HttpRequestMessage request)
        {
            using (var response = await httpClient.SendAsync(request))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await _jsonSerializer.DeserializeAsync<T>(response.Content);
            }
        }

        private static HttpClient GetOrCreateHttpClient(string baseUrl)
        {
            if (_httpClientsCache.TryGetValue(baseUrl, out var result))
            {
                return result;
            }

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            if (!_httpClientsCache.TryAdd(baseUrl, httpClient))
            {
                httpClient.Dispose();
            }

            return _httpClientsCache[baseUrl];
        }
    }
}
