using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Clients
{
    public class StoreClient : BaseClient, IStoreClient
    {
        public async Task<StoreItemsResult> GetStoreItemsAsync(ApiRequestModel apiRequestModel, string filter)
        {
            var requestUrl = "store_items";

            var requestBody = new
            {
                filter
            };

            using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<StoreItemsResult>(response);
            }
        }
    }
}
